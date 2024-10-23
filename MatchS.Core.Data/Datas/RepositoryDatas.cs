using MatchS.Core.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MatchS.Core.Data.Datas
{
    public class RepositoryDatas<T> : IRepositoryDatas<T> where T : class
    {
        private readonly AppDbContext _appDbContext;
        DbSet<T> _object;

        public RepositoryDatas(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _object = _appDbContext.Set<T>();
        }

        public async Task DeleteAsync(T t)
        {
            _object.Remove(t);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<List<T>> GetFilterListAsync(Expression<Func<T, bool>> filter) => await _object.Where(filter).ToListAsync();

        public async Task<List<T>> GetFilterListByNoTrackAsync(Expression<Func<T, bool>> filter) => await _object.Where(filter).AsNoTracking().ToListAsync();

        public async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter) => await _object.FirstOrDefaultAsync(filter);

        public async Task<List<T>> GetListAsync() => await _object.ToListAsync();

        public async Task<List<T>> GetListByNoTrackAsync() => await _object.AsNoTracking().ToListAsync();

        public async Task InsertAsync(T t)
        {
            await _object.AddAsync(t);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T t)
        {
            _object.Update(t);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
