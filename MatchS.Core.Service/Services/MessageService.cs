using MatchS.Core.Data.Interfaces;
using MatchS.Core.Entity.Core;
using MatchS.Core.Service.Interfaces;
using System.Linq.Expressions;

namespace MatchS.Core.Service.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageDatas _MessageDatas;
        public MessageService(IMessageDatas MessageDatas)
        {
            _MessageDatas = MessageDatas;
        }

        public async Task<List<Message>> GetListAsync()
        {
            return await _MessageDatas.GetListAsync();
        }

        public async Task<List<Message>> GetListByNoTrackAsync()
        {
            return await _MessageDatas.GetListByNoTrackAsync();
        }

        public async Task<List<Message>> GetFilterListAsync(Expression<Func<Message, bool>> filter)
        {
            return await _MessageDatas.GetFilterListAsync(filter);
        }

        public async Task<List<Message>> GetFilterListByNoTrackAsync(Expression<Func<Message, bool>> filter)
        {
            return await _MessageDatas.GetFilterListByNoTrackAsync(filter);
        }

        public async Task<Message> GetFirstOrDefaultAsync(Expression<Func<Message, bool>> filter)
        {
            return await _MessageDatas.GetFirstOrDefaultAsync(filter);
        }

        public async Task InsertAsync(Message t)
        {
            await _MessageDatas.InsertAsync(t);
        }

        public async Task DeleteAsync(Message t)
        {
            await _MessageDatas.DeleteAsync(t);
        }

        public async Task UpdateAsync(Message t)
        {
            await _MessageDatas.UpdateAsync(t);
        }
    }
}