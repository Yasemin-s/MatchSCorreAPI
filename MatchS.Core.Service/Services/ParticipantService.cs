using MatchS.Core.Data.Interfaces;
using MatchS.Core.Entity.Core;
using MatchS.Core.Service.Interfaces;
using System.Linq.Expressions;

namespace MatchS.Core.Service.Services
{
    public class ParticipantService : IParticipantService
    {
        private readonly IParticipantDatas _ParticipantDatas;
        public ParticipantService(IParticipantDatas ParticipantDatas)
        {
            _ParticipantDatas = ParticipantDatas;
        }

        public async Task<List<Participant>> GetListAsync()
        {
            return await _ParticipantDatas.GetListAsync();
        }

        public async Task<List<Participant>> GetListByNoTrackAsync()
        {
            return await _ParticipantDatas.GetListByNoTrackAsync();
        }

        public async Task<List<Participant>> GetFilterListAsync(Expression<Func<Participant, bool>> filter)
        {
            return await _ParticipantDatas.GetFilterListAsync(filter);
        }

        public async Task<List<Participant>> GetFilterListByNoTrackAsync(Expression<Func<Participant, bool>> filter)
        {
            return await _ParticipantDatas.GetFilterListByNoTrackAsync(filter);
        }

        public async Task<Participant> GetFirstOrDefaultAsync(Expression<Func<Participant, bool>> filter)
        {
            return await _ParticipantDatas.GetFirstOrDefaultAsync(filter);
        }

        public async Task InsertAsync(Participant t)
        {
            await _ParticipantDatas.InsertAsync(t);
        }

        public async Task DeleteAsync(Participant t)
        {
            await _ParticipantDatas.DeleteAsync(t);
        }

        public async Task UpdateAsync(Participant t)
        {
            await _ParticipantDatas.UpdateAsync(t);
        }
    }
}