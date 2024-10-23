using MatchS.Core.Data.Interfaces;
using MatchS.Core.Entity.Core;
using MatchS.Core.Service.Interfaces;
using System.Linq.Expressions;

namespace MatchS.Core.Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryDatas _CategoryDatas;
        public CategoryService(ICategoryDatas CategoryDatas)
        {
            _CategoryDatas = CategoryDatas;
        }

        public async Task<List<Category>> GetListAsync()
        {
            return await _CategoryDatas.GetListAsync();
        }

        public async Task<List<Category>> GetListByNoTrackAsync()
        {
            return await _CategoryDatas.GetListByNoTrackAsync();
        }

        public async Task<List<Category>> GetFilterListAsync(Expression<Func<Category, bool>> filter)
        {
            return await _CategoryDatas.GetFilterListAsync(filter);
        }

        public async Task<List<Category>> GetFilterListByNoTrackAsync(Expression<Func<Category, bool>> filter)
        {
            return await _CategoryDatas.GetFilterListByNoTrackAsync(filter);
        }

        public async Task<Category> GetFirstOrDefaultAsync(Expression<Func<Category, bool>> filter)
        {
            return await _CategoryDatas.GetFirstOrDefaultAsync(filter);
        }

        public async Task InsertAsync(Category t)
        {
            await _CategoryDatas.InsertAsync(t);
        }

        public async Task DeleteAsync(Category t)
        {
            await _CategoryDatas.DeleteAsync(t);
        }

        public async Task UpdateAsync(Category t)
        {
            await _CategoryDatas.UpdateAsync(t);
        }
    }
}