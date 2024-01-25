using AutoMapper;
using EXAMEN.Models.Eveniment;
using EXAMEN.Models.Participant;
using EXAMEN.Models.Participant.Dto;
using EXAMEN.Repositories.EvenimentRepository;
using EXAMEN.Repositories.ParticipantRepository;

namespace EXAMEN.Services
{
    public class ParticipantService : IParticipantService
    {
        private readonly IParticipantRepository _participantRepository;
        private readonly IEvenimentRepository _evenimentRepository;
        private readonly IMapper _mapper;

        public ParticipantService(IParticipantRepository participantRepository,
            IEvenimentRepository evenimentRepository, IMapper mapper)
        {
            _participantRepository = participantRepository;
            _evenimentRepository = evenimentRepository;
            _mapper = mapper;
        }

        public async Task<Participant> CreateParticipantAsync(ParticipantDto participantDto)
        {
            var participant = _mapper.Map<Participant>(participantDto);
            await _participantRepository.CreateAsync(participant);
            await _participantRepository.SaveAsync();
            return participant;
        }

        public async Task<IEnumerable<ParticipantDto>> GetAllParticipantsAsync()
        {
            var participants = await _participantRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ParticipantDto>>(participants);
        }

        public async Task<Participant> AddParticipantToEvenimentAsync(Guid idParticipant, Guid idEveniment)
        {
            var participant = await _participantRepository.getParticipantByIdAsync(idParticipant);
            var eveniment = await _evenimentRepository.getEvenimentByIdAsync(idEveniment);
            if (participant.Evenimente == null)
            {
                participant.Evenimente = new List<Eveniment>();
            }

            if (eveniment.Participanti == null)
            {
                eveniment.Participanti = new List<Participant>();
            }
            participant.Evenimente.Add(eveniment);
            eveniment.Participanti.Add(participant);
            _participantRepository.Update(participant);
            _participantRepository.SaveAsync();
            _evenimentRepository.Update(eveniment);
            _evenimentRepository.SaveAsync();
            return _mapper.Map<Participant>(participant);
        }
    }
}
