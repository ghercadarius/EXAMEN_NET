using EXAMEN.Models.Eveniment.Dto;
using EXAMEN.Repositories.EvenimentRepository;
using EXAMEN.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EXAMEN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvenimentController : ControllerBase
    {
        private readonly IEvenimentService _evenimentService;

        public EvenimentController(IEvenimentService evenimentService)
        {
            _evenimentService = evenimentService;
        }

        [HttpPost]
        public IActionResult CreateEveniment(EvenimentDto evenimentDto)
        {
            var result = _evenimentService.CreateEvenimentAsync(evenimentDto).Result;
            return result != null ? Ok(result) : BadRequest();
        }

        [HttpGet]
        public IActionResult GetAllEvenimente()
        {
            var result = _evenimentService.GetAllEvenimenteAsync().Result;
            return result != null ? Ok(result) : BadRequest();
        }

        [HttpPost]
        [Route("{idEveniment}/participant/{idParticipant}")]
        public IActionResult AddEvenimentToParticipant(Guid idEveniment, Guid idParticipant)
        {
            var result = _evenimentService.AddEvenimentToParticipantAsync(idEveniment, idParticipant).Result;
            return result != null ? Ok(result) : BadRequest();
        }
    }
}
