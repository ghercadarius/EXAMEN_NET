using AutoMapper;
using EXAMEN.Models.Dog;
using EXAMEN.Models.Dog.Dto;

namespace Examen.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            // CreateMap<Source, Destination>();
            CreateMap<Dog, DogDto>();
            CreateMap<DogDto, Dog>();
        }
    }
}
