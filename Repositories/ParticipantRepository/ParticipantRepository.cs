using EXAMEN.Models.Participant;
using Examen.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace EXAMEN.Repositories.ParticipantRepository
{
    public class ParticipantRepository : GenericRepository<Participant>, IParticipantRepository
    {
        public ParticipantRepository(ApplicationDbContext DbContext) : base(DbContext)
        {

        }

        public async Task<Participant> getParticipantByIdAsync(Guid id)
        {
            return await _applicationDbContext.Participanti.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
