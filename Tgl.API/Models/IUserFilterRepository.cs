using Tgl.Shared.Domain;

namespace Tgl.API.Models
{
    public interface IUserFilterRepository
    {
        Task<UserFilter> GetUserFilterAsync();
        Task<bool> SaveUserFilterAsync(UserFilter userFilter);
    }
}
