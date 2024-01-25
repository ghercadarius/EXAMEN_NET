using EXAMEN.Models.Participant.Dto;
using EXAMEN.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EXAMEN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantController : ControllerBase
    {
        private readonly IParticipantService _participantService;

        public ParticipantController(IParticipantService participantService)
        {
            _participantService = participantService;
        }

        [HttpPost]
        public IActionResult CreateParticipant(ParticipantDto participantDto)
        {
            var result = _participantService.CreateParticipantAsync(participantDto).Result;
            return result != null ? Ok(result) : BadRequest();
        }

        [HttpGet]
        public IActionResult GetAllParticipants()
        {
            var result = _participantService.GetAllParticipantsAsync().Result;
            return result != null ? Ok(result) : BadRequest();
        }

        [HttpPost]
        [Route("{idParticipant}/eveniment/{idEveniment}")]
        public IActionResult AddParticipantToEveniment(Guid idParticipant, Guid idEveniment)
        {
            var result = _participantService.AddParticipantToEvenimentAsync(idParticipant, idEveniment).Result;
            return result != null ? Ok(result) : BadRequest();
        }
    }
}
