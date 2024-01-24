using AutoMapper;
using EXAMEN.Models.Dog;
using EXAMEN.Models.Dog.Dto;
using EXAMEN.Models.Owner;
using EXAMEN.Models.Owner.Dto;

namespace Examen.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            // CreateMap<Source, Destination>();
            CreateMap<Dog, DogDto>();
            CreateMap<DogDto, Dog>();
            CreateMap<Owner, OwnerDto>();
            CreateMap<OwnerDto, Owner>();
        }
    }
}
