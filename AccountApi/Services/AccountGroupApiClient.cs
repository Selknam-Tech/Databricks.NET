using System.Text;
using System.Text.Json;
using Databricks.NET.AccountApi.Interfaces;
using Databricks.NET.AccountApi.Models;

namespace Databricks.NET.AccountApi.Services
{
    public class AccountGroupsApiClient : IAccountGroupsApiClient
    {

        private readonly HttpClient _httpClient;
        private readonly string _baseUri;
        private readonly string _accountId;

        public AccountGroupsApiClient(string baseUri, string token, string accountId)
        {
            _baseUri = baseUri;
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            _accountId = accountId;
        }

        public async Task<GroupResponse> ListGroupsAsync(string filter = null, string attributes = null, string excludedAttributes = null, int? startIndex = null, int? count = null, string sortBy = null, string sortOrder = "ascending")
        {
            var uriBuilder = new StringBuilder($"{_baseUri}/api/2.0/accounts/{_accountId}/scim/v2/Groups?");

            if (!string.IsNullOrWhiteSpace(filter))
                uriBuilder.Append($"filter={Uri.EscapeDataString(filter)}&");
            if (!string.IsNullOrWhiteSpace(attributes))
                uriBuilder.Append($"attributes={Uri.EscapeDataString(attributes)}&");
            if (!string.IsNullOrWhiteSpace(excludedAttributes))
                uriBuilder.Append($"excludedAttributes={Uri.EscapeDataString(excludedAttributes)}&");
            if (startIndex.HasValue)
                uriBuilder.Append($"startIndex={startIndex.Value}&");
            if (count.HasValue)
                uriBuilder.Append($"count={count.Value}&");
            if (!string.IsNullOrWhiteSpace(sortBy))
                uriBuilder.Append($"sortBy={Uri.EscapeDataString(sortBy)}&");
            if (!string.IsNullOrWhiteSpace(sortOrder))
                uriBuilder.Append($"sortOrder={sortOrder}");

            var requestUri = uriBuilder.ToString().TrimEnd('&');

            using var response = await _httpClient.GetAsync(requestUri);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var result = JsonSerializer.Deserialize<GroupResponse>(content, options);

            return result;
        }
    }
}