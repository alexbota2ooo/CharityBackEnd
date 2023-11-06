using CharityAPI.Model;
using CharityAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CharityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CauseController : ControllerBase
    {
        private readonly ICausesServices _causesServices;

        public CauseController(ICausesServices causesServices)
        {
            _causesServices = causesServices;
        }

        [HttpGet("GetAllCauses")]
        public async Task<IActionResult> GetAllCauses(int count)
        {
            var data = await _causesServices.GetAllCauses(count);
            if (!data.Success)
            {
                return StatusCode(500, new ServiceResponse { Message = "Exception thrown." });
            }
            else if (data.Payload == null)
            {
                return NotFound(data);
            }

            return Ok(data.Payload);
        }
    }
}
