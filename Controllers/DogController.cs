using EXAMEN.Models.Dog;
using EXAMEN.Models.Dog.Dto;
using EXAMEN.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EXAMEN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogController : ControllerBase
    {
        private readonly IDogService _dogService;

        public DogController(IDogService dogService)
        {
            _dogService = dogService;
        }


        [HttpPost]
        public IActionResult CreateDog(DogDto dogDto)
        {
            // i want to return the entity created
            var result = _dogService.CreateDogAsync(dogDto).Result;
            return result != null ? Ok(result) : BadRequest();
        }

        [HttpGet]
        public IActionResult GetAllDogs()
        {
            var result = _dogService.GetAllDogsAsync().Result;
            return result != null ? Ok(result) : BadRequest();
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetDogById(Guid id)
        {
            var result = _dogService.getDogByIdAsync(id).Result;
            return result != null ? Ok(result) : BadRequest();
        }

    }
}
