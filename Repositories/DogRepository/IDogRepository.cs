using Examen.Repositories.GenericRepository;
using EXAMEN.Models.Dog;
using EXAMEN.Models.Owner;

namespace EXAMEN.Repositories.DogRepository
{
    public interface IDogRepository : IGenericRepository<Dog>
    {
        Task<Dog> getDogByIdAsync(Guid id);

        Task<Owner> getOwnerByIdAsync(Guid id);

        Task<ICollection<Dog>> getDogsByOwnerIdAsync(Guid id);
    }

}
