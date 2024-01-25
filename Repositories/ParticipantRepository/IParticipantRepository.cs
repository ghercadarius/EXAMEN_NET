using EXAMEN.Models.Participant;
using Examen.Repositories.GenericRepository;

namespace EXAMEN.Repositories.ParticipantRepository
{
    public interface IParticipantRepository : IGenericRepository<Participant>
    {
        Task<Participant> getParticipantByIdAsync(Guid id);
    }
}
