using Databricks.NET.AccountApi.Interfaces;
using Databricks.NET.AccountApi.Services;

namespace Databricks.NET
{
    public class DatabricksApiClient
    {
        private readonly IAccountGroupsApiClient _accountGroupsApi;
        private readonly IAccountUserApiClient _accountUserApi;

        public IAccountGroupsApiClient AccountGroupsApi => _accountGroupsApi;
        public IAccountUserApiClient  AccountUserApi => _accountUserApi;



        public DatabricksApiClient(string apiToken, string accountId, string baseUri)
        {
            string _accountId = accountId;
            string _apiToken = apiToken;
            string _baseUri = baseUri;


            _accountGroupsApi = new AccountGroupsApiClient(_baseUri, _apiToken, _accountId);
            _accountUserApi = new AccountUserApiClient(_baseUri, _apiToken, _accountId);
        }


        
    }
}