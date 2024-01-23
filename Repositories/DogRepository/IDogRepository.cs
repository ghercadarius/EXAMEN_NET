using Examen.Repositories.GenericRepository;
using EXAMEN.Models.Dog;

namespace EXAMEN.Repositories.DogRepository
{
    public interface IDogRepository : IGenericRepository<Dog>
    {
        Task<Dog> getDogByIdAsync(Guid id);
    }

}
