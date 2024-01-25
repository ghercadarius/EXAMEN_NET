using EXAMEN.Models.Participant;
using EXAMEN.Models.Participant.Dto;

namespace EXAMEN.Services
{
    public interface IParticipantService
    {
        Task<IEnumerable<ParticipantDto>> GetAllParticipantsAsync();

        Task<Participant> CreateParticipantAsync(ParticipantDto participantDto);

        Task<Participant> AddParticipantToEvenimentAsync(Guid idParticipant, Guid idEveniment);
    }
}
