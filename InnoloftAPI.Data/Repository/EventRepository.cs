using InnoloftAPI.Core.Interface;
using InnoloftAPI.Core.Model;
using InnoloftAPI.Data.ContextData;
using Microsoft.EntityFrameworkCore;

namespace InnoloftAPI.Data.EventRepository
{
    public class EventRepository : IEventEventRepository
    {
        private readonly AppDbContext repository;
        public EventRepository(AppDbContext context)
        {
            repository = context;
        }

        public async Task<int> AddEventParticipant(EventParticipant model)
        {
            var entityEntry = repository.EventParticipants.Add(model);
            await repository.SaveChangesAsync();
            return entityEntry.Entity.ID;
        }

        public async Task<bool> AddEvents(Event model)
        {
            repository.Events.Add(model);
            await repository.SaveChangesAsync();
            return true;
        }

        public async Task<int> AddParticipantEvents(Participant model)
        {
            var entityEntry = repository.Participants.Add(model);
            await repository.SaveChangesAsync();
            return entityEntry.Entity.ID;
        }

        public async Task DeleteEvents(int id)
        {
            var DeleteList = repository.Events.FirstOrDefault(x => x.ID == id);
            repository.Events.Remove(DeleteList);
            await repository.SaveChangesAsync();
        }
        public async Task<Event> GetEventById(int id)
        {
            return await repository.Events.FirstOrDefaultAsync(z => z.ID == id);
        }
        public async Task DeleteParticipantEvents(int id)
        {
            var DeleteList = repository.Participants.FirstOrDefault(x => x.ID == id);
            repository.Participants.Remove(DeleteList);
            await repository.SaveChangesAsync();
        }

        public async Task EditEvents(Event model)
        {
            /*var test = repository.Events.FirstOrDefault(x => x.ID == model.ID);*/
            repository.Events.Update(model);
            await repository.SaveChangesAsync();
        }

        public async Task EditParticipantEvents(Participant model)
        {
            repository.Participants.Update(model);
            await repository.SaveChangesAsync();
        }
        public async Task<List<Event>> GetAllEvents()
        {
            return await repository.Events.ToListAsync();
        }
        public async Task<List<Event>> GetAllEventsPaginated(PaginatedRequest request)
        {
            int skipCount = request.CurrentPage * request.PageSize;
            return await repository.Events.Skip(skipCount).Take(request.PageSize).ToListAsync();

        }
        public async Task<List<Participant>> GetAllParticipantEvents()
        {
            return await repository.Participants.ToListAsync();
        }

        public async Task<List<Participant>> GetAllParticipantPaginated(PaginatedRequest request)
        {
            int skipCount = request.CurrentPage * request.PageSize;
            return await repository.Participants.Skip(skipCount).Take(request.PageSize).ToListAsync();

        }
    }
}

