using Tgl.Shared.Domain;

namespace Tgl.Data.Repositories
{
    public interface IUserFilterRepository
    {
        Task<UserFilter> GetUserFilterAsync();
        Task<bool> SaveUserFilterAsync(UserFilter userFilter);
    }
}
