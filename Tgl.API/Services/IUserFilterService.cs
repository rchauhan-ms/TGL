using Tgl.Shared.Domain;

namespace Tgl.API.Services
{
    public interface IUserFilterService
    {
        Task<UserFilter> GetUserFilterAsync();
        Task<bool> SaveUserFilterAsync(UserFilter userFilter);
    }
}
