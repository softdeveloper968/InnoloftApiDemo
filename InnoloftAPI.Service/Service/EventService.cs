using InnoloftAPI.Core.Interface;
using InnoloftAPI.Core.Model;
using Newtonsoft.Json;

namespace InnoloftAPI.Service.Service
{

    public class EventService : IEventService
    {
        private readonly IEventEventRepository _context;
        private readonly ICacheService _cacheservice;

        public EventService(IEventEventRepository context , ICacheService cacheservice)
        {
            _context = context;
            _cacheservice = cacheservice;
        }
        public async Task<bool> AddEvents(Event model)
        {

            await _cacheservice.RemoveValueAsync("EventDataForParticipant");
            await _cacheservice.RemoveValueAsync("EventData");
            return await _context.AddEvents(model);
        }

        public async Task EditEvents(Event model)
        {
            await _cacheservice.RemoveValueAsync("EventDataForParticipant");
            await _cacheservice.RemoveValueAsync("EventData");
            await _context.EditEvents(model);
        }

        public async Task DeleteEvents(int id)
        {
            await _cacheservice.RemoveValueAsync("EventDataForParticipant");
            await _cacheservice.RemoveValueAsync("EventData");
            await _context.DeleteEvents(id);
        }
        public async Task<Event> GetEventById(int id)
        {
            return await _context.GetEventById(id);
        }
        public async Task<List<Event>> GetAllEvents()
        {
            return await _context.GetAllEvents();
        }

        public async Task<List<Event>> GetAllEventsPaginated(PaginatedRequest request)
        {
            var cacheValue = await _cacheservice.GetValueAsync("EventData");
         
            if (cacheValue != null)
            {
                return JsonConvert.DeserializeObject<List<Event>>(cacheValue);
            }
            else {
                var events = await  _context.GetAllEventsPaginated(request);
                await _cacheservice.SetValueAsync("EventData", JsonConvert.SerializeObject(events));
                return  events;
            }
        }

        public async Task<int> AddParticipantEvents(Participant model)
        {
            await _cacheservice.RemoveValueAsync("EventDataForParticipant");
            await _cacheservice.RemoveValueAsync("EventData");
            return await _context.AddParticipantEvents(model);
        }
    
        public async Task DeleteParticipantEvents(int id)
        {
            await _cacheservice.RemoveValueAsync("EventDataForParticipant");
            await _cacheservice.RemoveValueAsync("EventData");
            await _context.DeleteParticipantEvents(id);
        }

       
        public async Task EditParticipantEvents(Participant model)
        {
            await _cacheservice.RemoveValueAsync("EventDataForParticipant");
            await _cacheservice.RemoveValueAsync("EventData");
            await _context.EditParticipantEvents(model);
        }

        public async Task<List<Participant>> GetAllParticipantEvents()
        {
            return await _context.GetAllParticipantEvents();
        }

        public async Task<List<Participant>> GetAllParticipantPaginated(PaginatedRequest request)
        {
            var cacheValue = await _cacheservice.GetValueAsync("EventDataForParticipant");

            if (cacheValue != null)
            {
                return JsonConvert.DeserializeObject<List<Participant>>(cacheValue);
            }
            else
            {
                var events = await _context.GetAllParticipantPaginated(request);
                await _cacheservice.SetValueAsync("EventDataForParticipant", JsonConvert.SerializeObject(events));
                return events;
            }

        }

        public async Task<int> AddEventParticipant(EventParticipant model)
        {
            return await _context.AddEventParticipant(model);
        }
    }
    }
