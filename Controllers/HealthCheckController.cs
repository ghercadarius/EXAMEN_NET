using EXAMEN.Data.ApiResponse;
using EXAMEN.Data.ApiResponse.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EXAMEN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var data = new { Name = "I'm alive" };
            var response = new OkResponse<object>(data);
            return Ok(data);
        }
    }
}
