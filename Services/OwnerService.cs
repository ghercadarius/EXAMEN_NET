using AutoMapper;
using EXAMEN.Models.Dog;
using EXAMEN.Models.Dog.Dto;
using EXAMEN.Models.Owner;
using EXAMEN.Models.Owner.Dto;
using EXAMEN.Repositories.DogRepository;
using EXAMEN.Repositories.OwnerRepository;

namespace EXAMEN.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly IDogRepository _dogRepository;
        private readonly IMapper _mapper;

        public OwnerService(IOwnerRepository ownerRepository, IDogRepository dogRepository, IMapper mapper)
        {
            _ownerRepository = ownerRepository;
            _dogRepository = dogRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OwnerDto>> GetAllOwnersAsync()
        {
            var owners = await _ownerRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<OwnerDto>>(owners); ;
        }

        public async Task<Owner> CreateOwnerAsync(OwnerDto ownerDto)
        {
            var owner = _mapper.Map<Owner>(ownerDto);
            await _ownerRepository.CreateAsync(owner);
            await _ownerRepository.SaveAsync();
            return owner;
        }

        public async Task<Owner> GetOwnerByIdAsync(Guid id)
        {
            var owner = await _ownerRepository.GetByIdAsync(id);
            return _mapper.Map<Owner>(owner);
        }

        public async Task<Dog> AddDogToOwnerAsync(Guid idOwner, Guid idDog)
        {
           var dog = await _dogRepository.getDogByIdAsync(idDog);
           dog.OwnerId = idOwner;
           dog.Owner = await _ownerRepository.GetByIdAsync(idOwner);
           _dogRepository.Update(dog);
           _dogRepository.SaveAsync();
           //await _dogRepository.CreateAsync(dog);
           return _mapper.Map<Dog>(dog);
        }

        public async Task<IEnumerable<DogDto>> GetDogsByOwnerIdAsync(Guid id)
        {
            var dogs = await _dogRepository.getDogsByOwnerIdAsync(id);
            return _mapper.Map<IEnumerable<DogDto>>(dogs);
        }
    }
}
