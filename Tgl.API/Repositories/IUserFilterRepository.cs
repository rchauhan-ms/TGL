using Tgl.Shared.Domain;

namespace Tgl.API.Repositories
{
    public interface IUserFilterRepository
    {
        Task<UserFilter> GetUserFilterAsync();
        Task<bool> SaveUserFilterAsync(UserFilter userFilter);
    }
}
