using EXAMEN.Models.Eveniment;
using EXAMEN.Models.Eveniment.Dto;

namespace EXAMEN.Services
{
    public interface IEvenimentService
    {
        Task<IEnumerable<EvenimentDto>> GetAllEvenimenteAsync();

        Task<Eveniment> CreateEvenimentAsync(EvenimentDto evenimentDto);
        Task<Eveniment> AddEvenimentToParticipantAsync(Guid idEveniment, Guid idParticipant);
    }
}
