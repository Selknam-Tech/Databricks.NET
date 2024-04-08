using Databricks.NET.AccountApi.Interfaces;
using Databricks.NET.AccountApi.Services;

namespace Databricks.NET
{
    public class DatabricksApiClient
    {
        private readonly IAccountGroupsApiClient _accountGroupsApi;
        private readonly string _apiToken;
        private readonly string _accountId;
        private readonly string _baseUri;


        public DatabricksApiClient(string apiToken, string accountId, string baseUri)
        {
            _accountId = accountId;
            _apiToken = apiToken;
            _baseUri = baseUri;


            _accountGroupsApi = new AccountGroupsApiClient(_baseUri, _apiToken, _accountId);
        }


        
    }
}