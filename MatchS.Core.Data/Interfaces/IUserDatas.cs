using MatchS.Core.Entity.Core;

namespace MatchS.Core.Data.Interfaces
{
    public interface IUserDatas : IRepositoryDatas<User>
    {
        Task<User> LoginAsync(string userName, string password);
    }
}