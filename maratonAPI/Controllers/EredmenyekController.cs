using maratonAPI.Models;
using maratonAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace maratonAPI.Controllers
{
    [Route("api/results")]
    [ApiController]
    public class EredmenyekController : ControllerBase
    {
        private readonly EredmenyekInterface eredmenyInterface;

        public EredmenyekController(EredmenyekInterface eredmenyInterface)
        {
            this.eredmenyInterface = eredmenyInterface;
        }

        [HttpPost]
        public async Task<ActionResult> PostNewResult(Eredmenyek eredmenyek)
        {
            var ered = await eredmenyInterface.NewResult(eredmenyek);
            if(ered != null)
            {
                return Ok(new { result = ered, message = "Sikeres lekérdezés." });
            }
            Exception e = new();
            return Ok(new { result = ered, message = e.Message });
        }
    }
}
