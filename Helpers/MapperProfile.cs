using AutoMapper;
using EXAMEN.Models.Eveniment;
using EXAMEN.Models.Eveniment.Dto;
using EXAMEN.Models.Participant;
using EXAMEN.Models.Participant.Dto;

namespace Examen.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            // CreateMap<Source, Destination>();
            CreateMap<Participant, ParticipantDto>();
            CreateMap<ParticipantDto, Participant>();
            CreateMap<Eveniment, EvenimentDto>();
            CreateMap<EvenimentDto, Eveniment>();
        }
    }
}
