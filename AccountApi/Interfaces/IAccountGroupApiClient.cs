using Databricks.NET.AccountApi.Models;

namespace Databricks.NET.AccountApi.Interfaces
{
    public interface IAccountGroupsApiClient
    {
        Task<GroupResponse> ListGroupsAsync(string filter = null, string attributes = null, string excludedAttributes = null, int? startIndex = null, int? count = null, string sortBy = null, string sortOrder = "ascending");
    }
}