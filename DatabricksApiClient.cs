using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Databricks.NET
{
    public class DatabricksApiClient
    {
        private readonly IAccountsApiService _accountsApi;
        private readonly string _apiToken;
        private readonly string _accountId;

        public DatabriksApiClient(string apiToken, string accountId)
        {
            _accountApi = accountApi;

            // Aquí instancias tus servicios, pasando la configuración necesaria
            // Por ejemplo, inicializando AccountsApiService con el apiToken
            var baseUri = "https://<tu-instancia-databricks>.azuredatabricks.net"; // Asegúrate de reemplazar <tu-instancia-databricks> con tu instancia real
            _accountsApi = new AccountsApi(baseUri, _apiToken);
        }


        
    }
}