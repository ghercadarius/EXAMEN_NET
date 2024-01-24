using Examen.Repositories.GenericRepository;
using EXAMEN.Models.Owner;

namespace EXAMEN.Repositories.OwnerRepository
{
    public interface IOwnerRepository : IGenericRepository<Owner>
    {
        Task DeleteAsync(Owner owner);
        Task<Owner> GetByIdAsync(Guid id);
        Task UpdateAsync(Owner owner);
    }
}
