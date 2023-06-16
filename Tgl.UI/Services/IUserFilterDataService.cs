using Tgl.Shared.Domain;

namespace Tgl.UI.Services
{
    public interface IUserFilterDataService
    {
        Task<UserFilter> GetUserFilterAsync();
        Task<bool> SaveUserFilterAsync(UserFilter userFilter);
    }
}
