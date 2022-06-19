using Microsoft.AspNetCore.Mvc;
using SES.Services.Abstract;

namespace SES.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class KataController : ControllerBase
	{
        private readonly IKataService kataService;
        public KataController(IKataService _kataService)
        {
            kataService = _kataService;
        }

        // POST api/kata
        [HttpPost]
        public IActionResult Post([FromBody] int[] seqValues)
        {
            var result = kataService.FindOddNumberTimes(seqValues);
            return Ok(result);
        }
    }
}
