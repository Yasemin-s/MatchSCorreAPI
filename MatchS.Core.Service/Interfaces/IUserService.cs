using MatchS.Core.Entity.Core;

namespace MatchS.Core.Service.Interfaces
{
    public interface IUserService : IRepositoryService<User>
    {
        Task<User> LoginAsync(string userName, string password);
    }
}