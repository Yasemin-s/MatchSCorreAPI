using MatchS.Core.Data.Interfaces;
using MatchS.Core.Entity.Core;
using Microsoft.EntityFrameworkCore;

namespace MatchS.Core.Data.Datas
{
    public class AdvertDatas : RepositoryDatas<Advert>, IAdvertDatas
    {
        private readonly AppDbContext _appDbContext;
        public AdvertDatas(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async  Task<List<Advert>> GetAdvertsWithComments()
        {
            return await _appDbContext.Adverts.Where(x => x.IsActive == true).Include(x => x.Comments).ToListAsync();
        }
    }
}