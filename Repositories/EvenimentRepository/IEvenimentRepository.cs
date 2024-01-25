using EXAMEN.Models.Eveniment;
using Examen.Repositories.GenericRepository;

namespace EXAMEN.Repositories.EvenimentRepository
{
    public interface IEvenimentRepository : IGenericRepository<Eveniment>
    {
        Task<Eveniment> getEvenimentByIdAsync(Guid id);
    }
}
