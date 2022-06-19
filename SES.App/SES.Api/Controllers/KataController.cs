using Microsoft.AspNetCore.Mvc;
using SES.Models.ViewModels;
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

        // POST api/Kata/GetResult
        [HttpPost("GetResult")]
        public IActionResult Post(KataRequestModel requestModel)
        {
			if (requestModel == null || requestModel.NumberList == null)
			{
                return BadRequest();
			}

            var result = kataService.FindOddNumberTimes(requestModel.NumberList);
            return Ok(result);
        }
    }
}
