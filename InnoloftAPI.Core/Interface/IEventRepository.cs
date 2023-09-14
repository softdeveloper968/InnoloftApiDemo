using InnoloftAPI.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnoloftAPI.Core.Interface
{
    public interface IEventEventRepository
    {
        public Task<bool> AddEvents(Event model);
        public Task EditEvents(Event model);
        public Task DeleteEvents(int id);
        public Task<Event> GetEventById(int id);
        public Task<List<Event>> GetAllEvents();
        public Task<int> AddParticipantEvents(Participant model);
        public Task EditParticipantEvents(Participant model);
        public Task DeleteParticipantEvents(int id);
        public Task<List<Participant>> GetAllParticipantEvents();
        public Task<int> AddEventParticipant(EventParticipant model);
        public Task<List<Event>> GetAllEventsPaginated(PaginatedRequest request);

        public Task<List<Participant>> GetAllParticipantPaginated(PaginatedRequest request);

    }
}
