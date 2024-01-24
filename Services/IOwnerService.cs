using EXAMEN.Models.Dog;
using EXAMEN.Models.Dog.Dto;
using EXAMEN.Models.Owner;
using EXAMEN.Models.Owner.Dto;

namespace EXAMEN.Services
{
    public interface IOwnerService
    {
        Task<IEnumerable<OwnerDto>> GetAllOwnersAsync();
        Task<Owner> CreateOwnerAsync(OwnerDto ownerDto);

        Task<Owner> GetOwnerByIdAsync(Guid id);

        Task<Dog> AddDogToOwnerAsync(Guid idOwner, Guid idDog);

        Task<IEnumerable<DogDto>> GetDogsByOwnerIdAsync(Guid id);
    }
}
