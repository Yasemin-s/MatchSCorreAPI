using MatchS.Core.Entity.Core;

namespace MatchS.Core.Service.Interfaces
{
    public interface IAdvertService:IRepositoryService<Advert>
    {
        Task<List<Advert>> GetAdvertsWithComments();
    }
}