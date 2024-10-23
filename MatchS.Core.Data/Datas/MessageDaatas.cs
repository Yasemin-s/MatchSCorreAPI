using MatchS.Core.Data.Interfaces;
using MatchS.Core.Entity.Core;

namespace MatchS.Core.Data.Datas
{
    public class MessageDatas : RepositoryDatas<Message>, IMessageDatas
    {
        private readonly AppDbContext _appDbContext;
        public MessageDatas(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }
    }
}