using EXAMEN.Models.Owner.Dto;
using EXAMEN.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EXAMEN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        [HttpPost]
        public IActionResult CreateOwner(OwnerDto ownerDto)
        {
            var result = _ownerService.CreateOwnerAsync(ownerDto).Result;
            return result != null ? Ok(result) : BadRequest();
        }

        [HttpGet]
        public IActionResult GetAllOwners()
        {
            var result = _ownerService.GetAllOwnersAsync().Result;
            return result != null ? Ok(result) : BadRequest();
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetOwnerById(Guid id)
        {
            var result = _ownerService.GetOwnerByIdAsync(id).Result;
            return result != null ? Ok(result) : BadRequest();
        }

        [HttpGet]
        [Route("{id}/dogs")]
        public IActionResult GetDogsByOwnerId(Guid id)
        {
            var result = _ownerService.GetDogsByOwnerIdAsync(id).Result;
            return result != null ? Ok(result) : BadRequest();
        }

        [HttpPost]
        [Route("{idOwner}/dogs/{idDog}")]
        public IActionResult AddDogToOwner(Guid idOwner, Guid idDog)
        {
            var result = _ownerService.AddDogToOwnerAsync(idOwner, idDog).Result;
            return result != null ? Ok(result) : BadRequest();
        }

    }
}
