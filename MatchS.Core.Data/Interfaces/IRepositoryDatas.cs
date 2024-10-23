using System.Linq.Expressions;

namespace MatchS.Core.Data.Interfaces
{
    public interface IRepositoryDatas<T>
    {
        Task<List<T>> GetListAsync();
        Task<List<T>> GetListByNoTrackAsync();
        Task<List<T>> GetFilterListAsync(Expression<Func<T, bool>> filter);
        Task<List<T>> GetFilterListByNoTrackAsync(Expression<Func<T, bool>> filter);
        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter);
        Task InsertAsync(T t);
        Task DeleteAsync(T t);
        Task UpdateAsync(T t);
    }
}