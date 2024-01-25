using EXAMEN.Models.Eveniment;
using Examen.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace EXAMEN.Repositories.EvenimentRepository
{
    public class EvenimentRepository : GenericRepository<Eveniment>, IEvenimentRepository
    {
        public EvenimentRepository(ApplicationDbContext DbContext) : base(DbContext)
        {

        }

        public async Task<Eveniment> getEvenimentByIdAsync(Guid id)
        {
            return await _applicationDbContext.Evenimente.FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
