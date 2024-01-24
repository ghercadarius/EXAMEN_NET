using EXAMEN.Models.Dog;
using Examen.Repositories.GenericRepository;
using Microsoft.Identity.Client;
using Microsoft.EntityFrameworkCore;
using EXAMEN.Models.Owner;

namespace EXAMEN.Repositories.DogRepository
{
    public class DogRepository : GenericRepository<Dog>, IDogRepository
    {
        public DogRepository(ApplicationDbContext DbContext) : base(DbContext)
        {
           
        }
    
        public async Task<Dog> getDogByIdAsync(Guid id)
        {
            return await _applicationDbContext.Dogs.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Owner> getOwnerByIdAsync(Guid id)
        {
            return await _applicationDbContext.Owners.FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<ICollection<Dog>> getDogsByOwnerIdAsync(Guid id)
        {
            //get all dogs which have ownerid = id
            return await _applicationDbContext.Dogs.Where(o => o.OwnerId == id).ToListAsync();
        }

    }

}
