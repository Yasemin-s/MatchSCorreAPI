using MatchS.Core.Data.Interfaces;
using MatchS.Core.Entity.Core;

namespace MatchS.Core.Data.Datas
{
    public class ParticipantDatas : RepositoryDatas<Participant>, IParticipantDatas
    {
        private readonly AppDbContext _appDbContext;
        public ParticipantDatas(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }
    }
}