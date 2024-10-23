using MatchS.Core.Data.Interfaces;
using MatchS.Core.Entity.Core;

namespace MatchS.Core.Data.Datas
{
    public class CommentDatas : RepositoryDatas<Comment>, ICommentDatas
    {
        private readonly AppDbContext _appDbContext;
        public CommentDatas(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }
    }
}