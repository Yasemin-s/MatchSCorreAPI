using MatchS.Core.Data.Interfaces;
using MatchS.Core.Entity.Core;
using MatchS.Core.Service.Interfaces;
using System.Linq.Expressions;

namespace MatchS.Core.Service.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentDatas _CommentDatas;
        public CommentService(ICommentDatas CommentDatas)
        {
            _CommentDatas = CommentDatas;
        }

        public async Task<List<Comment>> GetListAsync()
        {
            return await _CommentDatas.GetListAsync();
        }

        public async Task<List<Comment>> GetListByNoTrackAsync()
        {
            return await _CommentDatas.GetListByNoTrackAsync();
        }

        public async Task<List<Comment>> GetFilterListAsync(Expression<Func<Comment, bool>> filter)
        {
            return await _CommentDatas.GetFilterListAsync(filter);
        }

        public async Task<List<Comment>> GetFilterListByNoTrackAsync(Expression<Func<Comment, bool>> filter)
        {
            return await _CommentDatas.GetFilterListByNoTrackAsync(filter);
        }

        public async Task<Comment> GetFirstOrDefaultAsync(Expression<Func<Comment, bool>> filter)
        {
            return await _CommentDatas.GetFirstOrDefaultAsync(filter);
        }

        public async Task InsertAsync(Comment t)
        {
            await _CommentDatas.InsertAsync(t);
        }

        public async Task DeleteAsync(Comment t)
        {
            await _CommentDatas.DeleteAsync(t);
        }

        public async Task UpdateAsync(Comment t)
        {
            await _CommentDatas.UpdateAsync(t);
        }
    }
}