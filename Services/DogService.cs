using AutoMapper;
using EXAMEN.Models.Dog;
using EXAMEN.Models.Dog.Dto;
using EXAMEN.Models.Owner;
using EXAMEN.Repositories.DogRepository;

namespace EXAMEN.Services
{
    public class DogService : IDogService
    {
        private readonly IDogRepository _dogRepository;
        private readonly IMapper _mapper;

        public DogService(IDogRepository dogRepository, IMapper mapper)
        {
            _dogRepository = dogRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DogDto>> GetAllDogsAsync()
        {
            var dogs = await _dogRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<DogDto>>(dogs);
        }

        public async Task<Dog> CreateDogAsync(DogDto dogDto)
        {
            var dog = _mapper.Map<Dog>(dogDto);
            await _dogRepository.CreateAsync(dog);
            await _dogRepository.SaveAsync();
            return dog;
        }

        public async Task<Dog> getDogByIdAsync(Guid id)
        {
            var dog = await _dogRepository.getDogByIdAsync(id);
            return _mapper.Map<Dog>(dog);
        }

        // Add other business logic methods as needed
    }

}
