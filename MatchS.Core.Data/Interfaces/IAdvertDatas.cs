using MatchS.Core.Entity.Core;

namespace MatchS.Core.Data.Interfaces
{
    public interface IAdvertDatas : IRepositoryDatas<Advert>
    {
        Task<List<Advert>> GetAdvertsWithComments();
    }
}