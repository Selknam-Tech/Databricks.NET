using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Databricks.NET.AccountApi.Interfaces;
using Databricks.NET.AccountApi.Models;
using Databricks.NET.AccountApi.Models.Request;
using Databricks.NET.AccountApi.Models.Response;

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

        public async Task<GroupResponse> ListGroupsAsync(GroupListRequest request)
        {
            var uriBuilder = new StringBuilder($"{_baseUri}/api/2.0/accounts/{_accountId}/scim/v2/Groups?");

            if (!string.IsNullOrWhiteSpace(request.Filter))
                uriBuilder.Append($"filter={Uri.EscapeDataString(request.Filter)}&");
            if (!string.IsNullOrWhiteSpace(request.Attributes))
                uriBuilder.Append($"attributes={Uri.EscapeDataString(request.Attributes)}&");
            if (!string.IsNullOrWhiteSpace(request.ExcludedAttributes))
                uriBuilder.Append($"excludedAttributes={Uri.EscapeDataString(request.ExcludedAttributes)}&");
            if (request.StartIndex.HasValue)
                uriBuilder.Append($"startIndex={request.StartIndex.Value}&");
            if (request.Count.HasValue)
                uriBuilder.Append($"count={request.Count.Value}&");
            if (!string.IsNullOrWhiteSpace(request.SortBy))
                uriBuilder.Append($"sortBy={Uri.EscapeDataString(request.SortBy)}&");
            if (!string.IsNullOrWhiteSpace(request.SortOrder))
                uriBuilder.Append($"sortOrder={request.SortOrder}");

            var requestUri = uriBuilder.ToString().TrimEnd('&');

            using var response = await _httpClient.GetAsync(requestUri);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var result = JsonSerializer.Deserialize<GroupResponse>(content, options);

            return result;
        }

        public async Task<Group> CreateGroupAsync(GroupCreationRequest request)
        {
            var content = JsonContent.Create(request);
            var response = await _httpClient.PostAsync($"{_baseUri}/api/2.0/accounts/{_accountId}/scim/v2/Groups", content);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Group>();
        }

        public async Task<Group> GetGroupAsync(string groupId)
        {
            var response = await _httpClient.GetAsync($"{_baseUri}/api/2.0/accounts/{_accountId}/scim/v2/Groups/{groupId}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Group>();
        }

        public async Task<Group> UpdateGroupAsync(string groupId, GroupUpdateRequest updateRequest)
        {
            var content = JsonContent.Create(updateRequest);
            var response = await _httpClient.PutAsync($"{_baseUri}/api/2.0/accounts/{_accountId}/scim/v2/Groups/{groupId}", content);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Group>();
        }

        public async Task DeleteGroupAsync(string groupId)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUri}/api/2.0/accounts/{_accountId}/scim/v2/Groups/{groupId}");
            response.EnsureSuccessStatusCode();
        }
    }
}