using AutoMapper;
using EXAMEN.Models.Eveniment;
using EXAMEN.Models.Eveniment.Dto;
using EXAMEN.Models.Participant;
using EXAMEN.Repositories.EvenimentRepository;
using EXAMEN.Repositories.ParticipantRepository;
using Microsoft.AspNetCore.Http.HttpResults;

namespace EXAMEN.Services
{
    public class EvenimentService : IEvenimentService
    {
        private readonly IEvenimentRepository _evenimentRepository;
        private readonly IParticipantRepository _participantRepository;
        private readonly IMapper _mapper;

        public EvenimentService(IEvenimentRepository evenimentRepository,
            IParticipantRepository participantRepository, IMapper mapper)
        {
            _evenimentRepository = evenimentRepository;
            _participantRepository = participantRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EvenimentDto>> GetAllEvenimenteAsync()
        {
            var evenimente = await _evenimentRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<EvenimentDto>>(evenimente);
        }

        public async Task<Eveniment> CreateEvenimentAsync(EvenimentDto evenimentDto)
        {
            var eveniment = _mapper.Map<Eveniment>(evenimentDto);
            await _evenimentRepository.CreateAsync(eveniment);
            await _evenimentRepository.SaveAsync();
            return eveniment;
        }

        public async Task<Eveniment> AddEvenimentToParticipantAsync(Guid idEveniment, Guid idParticipant)
        {
            var eveniment = await _evenimentRepository.getEvenimentByIdAsync(idEveniment);
            var participant = await _participantRepository.getParticipantByIdAsync(idParticipant);
            if (eveniment.Participanti == null)
            {
                eveniment.Participanti = new List<Participant>();
            }
            eveniment.Participanti.Add(participant);
            if (participant.Evenimente == null)
            {
                participant.Evenimente = new List<Eveniment>();
            }
            participant.Evenimente.Add(eveniment);
            _evenimentRepository.Update(eveniment);
            _evenimentRepository.SaveAsync();
            _participantRepository.Update(participant);
            _participantRepository.SaveAsync();
            return _mapper.Map<Eveniment>(eveniment);
        }
    }
}
