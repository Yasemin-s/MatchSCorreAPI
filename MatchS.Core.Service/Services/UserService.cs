using MatchS.Core.Data.Interfaces;
using MatchS.Core.Entity.Core;
using MatchS.Core.Service.Interfaces;
using System.Linq.Expressions;

namespace MatchS.Core.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserDatas _UserDatas;
        public UserService(IUserDatas UserDatas)
        {
            _UserDatas = UserDatas;
        }

        public async Task<List<User>> GetListAsync()
        {
            return await _UserDatas.GetListAsync();
        }

        public async Task<List<User>> GetListByNoTrackAsync()
        {
            return await _UserDatas.GetListByNoTrackAsync();
        }

        public async Task<List<User>> GetFilterListAsync(Expression<Func<User, bool>> filter)
        {
            return await _UserDatas.GetFilterListAsync(filter);
        }

        public async Task<List<User>> GetFilterListByNoTrackAsync(Expression<Func<User, bool>> filter)
        {
            return await _UserDatas.GetFilterListByNoTrackAsync(filter);
        }

        public async Task<User> GetFirstOrDefaultAsync(Expression<Func<User, bool>> filter)
        {
            return await _UserDatas.GetFirstOrDefaultAsync(filter);
        }

        public async Task InsertAsync(User t)
        {
            await _UserDatas.InsertAsync(t);
        }

        public async Task DeleteAsync(User t)
        {
            await _UserDatas.DeleteAsync(t);
        }

        public async Task UpdateAsync(User t)
        {
            await _UserDatas.UpdateAsync(t);
        }

        public async Task<User> LoginAsync(string userName, string password)
        {
           return await _UserDatas.LoginAsync(userName, password);
        }
    }
}