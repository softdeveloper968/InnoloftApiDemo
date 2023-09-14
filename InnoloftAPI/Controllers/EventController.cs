using AutoMapper;
using InnoloftAPI.Core.Interface;
using InnoloftAPI.Core.Model;
using InnoloftAPI.Core.Resources;
using InnoloftAPI.Service.Service;
using Microsoft.AspNetCore.Mvc;

namespace InnoloftAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;
        private readonly IMapper _mapper;
        public EventController(IEventService eventService, IMapper mapper)
        {
            _eventService = eventService;
            _mapper = mapper;
        }

        [HttpPost("AddEvents")]
        public async Task<IActionResult> AddEvents(EventViewModel user)
        {
            var authordtodata = _mapper.Map<Event>(user);
            return Ok(await _eventService.AddEvents(authordtodata));
        }

        [HttpPost("GetAllEventsPaginated")]
        public async Task<IActionResult> GetAllEventsPaginated(PaginatedRequest request)
        {
            var authordtodata = _mapper.Map<List<EventViewModel>>(await _eventService.GetAllEventsPaginated(request));
            return Ok(authordtodata);
        }

        [HttpPost("EditEvents")]
        public async Task<IActionResult> EditEvents(EventViewModel user)
        {
            if (user.ID == 0)
            {
                return Ok("Failed");
            }
            else
            {
                var authordtodata = _mapper.Map<Event>(user);
                await _eventService.EditEvents(authordtodata);
                return Ok(authordtodata);
            }
        }

        [HttpDelete("DeleteEvents")]
        public async Task<IActionResult> DeleteEvents(int id)
        {
            await _eventService.DeleteEvents(id);
            return Ok();
        }

        [HttpGet("GetAllEvents")]
        public async Task<IActionResult> GetAllEvents()
        {

            var authordtodata = _mapper.Map<List<EventViewModel>>(await _eventService.GetAllEvents());
            return Ok(authordtodata);
        }


        [HttpPost("AddParticipantEvents")]
        public async Task<IActionResult> AddParticipantEvents(ParticipantsViewModel user)
        {
            var authordtodata = _mapper.Map<Participant>(user);
            var id = await _eventService.AddParticipantEvents(authordtodata);
            var eventParticipantId = await _eventService.AddEventParticipant(new EventParticipant { EventID = user.EventID, ParticipantID = id });
            return Ok(id > 0);
        }
        // method for  update student data by their same writing their same id as first one
        [HttpPost("EditParticipantEvents")]
        public async Task<IActionResult> EditParticipantEvents(ParticipantsViewModel user)
        {
            if (user.ID == 0)
            {
                return Ok("Failed");
            }
            else
            {
                var authordtodata = _mapper.Map<Participant>(user);
                await _eventService.EditParticipantEvents(authordtodata);
                return Ok(authordtodata);
            }
        }

        [HttpDelete("DeleteParticipantEvents")]
        public async Task<IActionResult> DeleteParticipantEvents(int id)
        {
            await _eventService.DeleteParticipantEvents(id);
            return Ok();
        }

        [HttpGet("GetAllParticipantEvents")]
        public async Task<IActionResult> GetAllParticipantEvents()
        {

            var authordtodata = _mapper.Map<List<ParticipantsViewModel>>(await _eventService.GetAllParticipantEvents());
            return Ok(authordtodata);
        }

        [HttpPost("GetAllParticipantPaginated")]
        public async Task<IActionResult> GetAllParticipantPaginated(PaginatedRequest request)
        {
            var authordtodata = _mapper.Map<List<ParticipantsViewModel>>(await _eventService.GetAllParticipantPaginated(request));
            return Ok(authordtodata);
        }
        [HttpGet("GetEventById")]
        public async Task<IActionResult> GetEventById(int id)
        {

            return Ok(_mapper.Map<EventViewModel>(await _eventService.GetEventById(id)));
        }

    }
}
