using MatchS.Core.Data.Interfaces;
using MatchS.Core.Entity.Core;
using MatchS.Core.Service.Interfaces;
using System.Linq.Expressions;

namespace MatchS.Core.Service.Services
{
    public class AdvertService : IAdvertService
    {
        private readonly IAdvertDatas _advertDatas;
        public AdvertService(IAdvertDatas advertDatas)
        {
            _advertDatas = advertDatas;
        }

        public async Task<List<Advert>> GetListAsync()
        {
            return await _advertDatas.GetListAsync();
        }

        public async Task<List<Advert>> GetListByNoTrackAsync()
        {
            return await _advertDatas.GetListByNoTrackAsync();
        }

        public async Task<List<Advert>> GetFilterListAsync(Expression<Func<Advert, bool>> filter)
        {
            return await _advertDatas.GetFilterListAsync(filter);
        }

        public async Task<List<Advert>> GetFilterListByNoTrackAsync(Expression<Func<Advert, bool>> filter)
        {
            return await _advertDatas.GetFilterListByNoTrackAsync(filter);
        }

        public async Task<Advert> GetFirstOrDefaultAsync(Expression<Func<Advert, bool>> filter)
        {
            return await _advertDatas.GetFirstOrDefaultAsync(filter);
        }

        public async Task InsertAsync(Advert t)
        {
            await _advertDatas.InsertAsync(t);
        }

        public async Task DeleteAsync(Advert t)
        {
            await _advertDatas.DeleteAsync(t);
        }

        public async Task UpdateAsync(Advert t)
        {
            await _advertDatas.UpdateAsync(t);
        }

        public async Task<List<Advert>> GetAdvertsWithComments()
        {
            return await _advertDatas.GetAdvertsWithComments();
        }
    }
}