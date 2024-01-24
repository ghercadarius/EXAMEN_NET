using Examen.Repositories.GenericRepository;
using EXAMEN.Models.Owner;
using Microsoft.EntityFrameworkCore;

namespace EXAMEN.Repositories.OwnerRepository
{
    public class OwnerRepository : GenericRepository<Owner>, IOwnerRepository
    {
        public OwnerRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Owner> GetByIdAsync(Guid id)
        {
            return await _applicationDbContext.Owners.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Owner owner)
        {
            _applicationDbContext.Owners.Update(owner);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Owner owner)
        {
            _applicationDbContext.Owners.Remove(owner);
            await _applicationDbContext.SaveChangesAsync();
        }



    }
}
