using Databricks.NET.AccountApi.Models;
using Databricks.NET.AccountApi.Models.Request;
using Databricks.NET.AccountApi.Models.Response;

namespace Databricks.NET.AccountApi.Interfaces
{
    public interface IAccountGroupsApiClient
    {
        Task<GroupResponse> ListGroupsAsync(GroupListRequest request);
        Task<Group> CreateGroupAsync(GroupCreationRequest request);
        Task<Group> GetGroupAsync(string groupId);
        Task<Group> UpdateGroupAsync(string groupId, GroupUpdateRequest updateRequest);
        Task DeleteGroupAsync(string groupId);
    }
}