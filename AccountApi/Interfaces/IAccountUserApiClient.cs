using Databricks.NET.AccountApi.Models.Request;
using Databricks.NET.AccountApi.Models.Response;

namespace Databricks.NET.AccountApi.Interfaces
{
    public interface IAccountUserApiClient
    {
        Task<UserListResponse> ListUsersAsync(UserListRequest request);
        Task<UserCreationResponse> CreateUserAsync(UserCreationRequest userRequest);
    }
}
