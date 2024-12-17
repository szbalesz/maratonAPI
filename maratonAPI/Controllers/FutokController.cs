using maratonAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace maratonAPI.Controllers
{
    [Route("api/runners")]
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
        [HttpGet("byid")]
        public async Task<ActionResult> GetById(int id)
        {
            var runner = await futokInterface.ById(id);
            if (runner != null)
            {
                return Ok(new { result = runner, message = "Sikeres lekérdezés." });
            }
            return NotFound(new { result = runner, message = "Nincs ilyen futó." });
        }
        [HttpGet("runnerAllData")]
        public async Task<ActionResult> GetRunnerWithAllData(int id)
        {
            var runner = await futokInterface.RunnerWithAllData(id);
            if (runner != null)
            {
                return Ok(new { result = runner, message = "Sikeres lekérdezés." });
            }
            return NotFound(new { result = runner, message = "Nincs ilyen futó." });
        }
        [HttpGet("femalesrunners")]
        public async Task<ActionResult> GetAllFemaleRunners()
        {
            var females = await futokInterface.AllFemaleRunners();
            if (females != null)
            {
                return Ok(new { result = females, message = "Sikeres lekérdezés." });
            }
            Exception e = new();
            return BadRequest(new { result = females, message = e.Message });
        }
        [HttpGet("agerunners")]
        public async Task<ActionResult> GetRunnersAge()
        {
            var age = await futokInterface.RunnersAge();
            if (age != null)
            {
                return Ok(new { result = age, message = "Sikeres lekérdezés." });
            }
            Exception e = new();
            return BadRequest(new { result = age, message = e.Message });
        }
        [HttpGet("bestrunner")]
        public async Task<ActionResult> GetBestRunner()
        {
            var best = await futokInterface.BestRunner();
            if (best != null)
            {
                return Ok(new { result = best, message = "Sikeres lekérdezés." });
            }
            Exception e = new();
            return BadRequest(new { result = best, message = e.Message });
        }
    }
}
