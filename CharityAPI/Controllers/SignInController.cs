using CharityAPI.Model;
using CharityAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CharityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignInController : ControllerBase
    {
        private readonly ISignInServices _signInServices;

        public SignInController(ISignInServices signInServices)
        {
            _signInServices = signInServices;
        }

        [HttpPost("UserSignIn")]
        public async Task<IActionResult> UserSignIn(SignInRequest oSignIn)
        {
            var data = await _signInServices.UserSignIn(oSignIn);
            if (!data.Success)
            {
                return StatusCode(500, new ServiceResponse { Message = data.Message });
            }
            else if (data.Payload == null)
            {
                return NotFound(data);
            }

            return Ok(new ServiceResponse { Success = data.Success, Message = "XApiKey: " + data.Message, Payload = data.Payload }); ;
        }

        [HttpPost("UserSignUp")]
        public async Task<IActionResult> UserSignUp(SignUpRequest oSignUp)
        {
            var data = await _signInServices.UserSignUp(oSignUp);
            if (!data.Success)
            {
                return StatusCode(500, new ServiceResponse { Message = data.Message });
            }

            return Ok(new ServiceResponse { Success = data.Success, Message = data.Message, Payload = data.Payload }); ;
        }
    }
}
