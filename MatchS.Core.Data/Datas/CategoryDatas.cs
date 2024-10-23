using MatchS.Core.Data.Interfaces;
using MatchS.Core.Entity.Core;

namespace MatchS.Core.Data.Datas
{
    public class CategoryDatas : RepositoryDatas<Category>, ICategoryDatas
    {
        private readonly AppDbContext _appDbContext;
        public CategoryDatas(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }
    }
}