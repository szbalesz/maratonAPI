using maratonAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace maratonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FutokController : ControllerBase
    {
        private readonly FutokInterface futokInterface;

        public FutokController(FutokInterface futokInterface)
        {
            this.futokInterface = futokInterface;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllRunners()
        {
            var runners = await futokInterface.AllRunners();
            if(runners != null)
            {
                return Ok(new {result= runners, message  = "Sikeres lekérdezés."});
            }
            Exception e = new();
            return BadRequest(new { result = runners, message =  e.Message});
        }
        [HttpGet("id")]
        public async Task<ActionResult> GetById(int id)
        {
            var runner = await futokInterface.ById(id);
            if (runner != null)
            {
                return Ok(new { result = runner, message = "Sikeres lekérdezés." });
            }
            Exception e = new();
            return NotFound(new { result = runner, message = e.Message });
        }
    }
}
