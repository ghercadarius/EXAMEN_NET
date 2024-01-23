using EXAMEN.Models.Dog;
using Examen.Repositories.GenericRepository;
using Microsoft.Identity.Client;
using Microsoft.EntityFrameworkCore;

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

    }

}
