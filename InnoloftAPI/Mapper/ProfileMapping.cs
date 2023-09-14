using AutoMapper;
using InnoloftAPI.Core.Model;
using InnoloftAPI.Core.Resources;

namespace InnoloftAPI.Mapper
{
    public class ProfileMapping : Profile
    {
        public ProfileMapping()
        {
            CreateMap<EventViewModel, Event>().ReverseMap();
            CreateMap<ParticipantsViewModel, Participant>().ReverseMap();
        }
    }
}
