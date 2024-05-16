using Databricks.NET.AccountApi.Models;
using Databricks.NET.AccountApi.Models.Request;
using Databricks.NET.AccountApi.Models.Response;

namespace Databricks.NET.AccountApi.Interfaces
{
    public interface IAccountGroupsApiClient
    {
        Task<GroupResponse> ListGroupsAsync(GroupListRequest request);
        Task<Group> CreateGroupAsync(GroupCreationRequest request);
        Task GroupUpdateAsync(string groupId, PatchRequest patchRequest);
        Task<Group> GetGroupAsync(string groupId);
        Task DeleteGroupAsync(string groupId);
    }
}