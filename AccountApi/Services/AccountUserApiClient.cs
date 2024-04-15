using System.Net.Http.Json;
using System.Text.Json;
using Databricks.NET.AccountApi.Interfaces;
using Databricks.NET.AccountApi.Models.Request;
using Databricks.NET.AccountApi.Models.Response;

namespace Databricks.NET.AccountApi.Services
{
    public class AccountUserApiClient : IAccountUserApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUri;
        private readonly string _accountId;
        public AccountUserApiClient(string baseUri, string token, string accountId)
        {
            _baseUri = baseUri;
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            _accountId = accountId;
        }
        public async Task<UserListResponse> ListUsersAsync(UserListRequest request)
        {
            var queryParams = new List<string>();
            if (!string.IsNullOrWhiteSpace(request.Filter)) queryParams.Add($"filter={Uri.EscapeDataString(request.Filter)}");
            if (!string.IsNullOrWhiteSpace(request.Attributes)) queryParams.Add($"attributes={Uri.EscapeDataString(request.Attributes)}");
            if (!string.IsNullOrWhiteSpace(request.ExcludedAttributes)) queryParams.Add($"excludedAttributes={Uri.EscapeDataString(request.ExcludedAttributes)}");
            if (request.StartIndex.HasValue) queryParams.Add($"startIndex={request.StartIndex.Value}");
            if (request.Count.HasValue) queryParams.Add($"count={request.Count.Value}");
            if (!string.IsNullOrWhiteSpace(request.SortBy)) queryParams.Add($"sortBy={Uri.EscapeDataString(request.SortBy)}");
            if (!string.IsNullOrWhiteSpace(request.SortOrder)) queryParams.Add($"sortOrder={request.SortOrder}");

            var queryString = string.Join("&", queryParams);
            var requestUri = $"{_baseUri}/api/2.0/accounts/{_accountId}/scim/v2/Users?{queryString}";

            using var response = await _httpClient.GetAsync(requestUri);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var result = JsonSerializer.Deserialize<UserListResponse>(content, options);

            return result;
        }


        public async Task<UserCreationResponse> CreateUserAsync(UserCreationRequest userRequest)
        {
            var content = JsonContent.Create(userRequest);
            var response = await _httpClient.PostAsync($"{_baseUri}/api/2.0/accounts/{_accountId}/scim/v2/Users", content);
            response.EnsureSuccessStatusCode();

            var responseData = await response.Content.ReadAsStringAsync();
            var userResponse = JsonSerializer.Deserialize<UserCreationResponse>(responseData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return userResponse;
        }
    }
}