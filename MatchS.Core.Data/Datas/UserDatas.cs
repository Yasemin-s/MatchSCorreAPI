using MatchS.Core.Data.Interfaces;
using MatchS.Core.Entity.Core;
using Microsoft.EntityFrameworkCore;

namespace MatchS.Core.Data.Datas
{
    public class UserDatas : RepositoryDatas<User>, IUserDatas
    {
        private readonly AppDbContext _appDbContext;
        public UserDatas(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<User> LoginAsync(string userName, string password)
        {
            return await _appDbContext.Users.FirstOrDefaultAsync(x => x.UserName == userName && x.Password == password);
        }
    }
}