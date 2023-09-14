using InnoloftAPI.Core.Model;

namespace InnoloftAPI.Core.Interface
{
    public interface IEventService
    {
        public Task<bool> AddEvents(Event model);
        public Task EditEvents(Event model);
        public Task DeleteEvents(int id);
        public Task<List<Event>> GetAllEvents(); 
        public Task<Event> GetEventById(int id);

        public Task<int> AddParticipantEvents(Participant model);
        public Task EditParticipantEvents(Participant model);
        public Task DeleteParticipantEvents(int id);
        public Task<List<Participant>> GetAllParticipantEvents();
        public Task<int> AddEventParticipant(EventParticipant model);
        public Task<List<Event>> GetAllEventsPaginated(PaginatedRequest request);
        public Task<List<Participant>> GetAllParticipantPaginated(PaginatedRequest request);
    }
}
