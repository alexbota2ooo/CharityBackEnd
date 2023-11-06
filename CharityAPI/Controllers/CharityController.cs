using CharityAPI.Entities;
using CharityAPI.Model;
using CharityAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;

namespace CharityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharityController : ControllerBase
    {
        private readonly ICharitiesServices _charitiesServices;

        public CharityController(ICharitiesServices charitiesServices)
        {
            _charitiesServices = charitiesServices;
        }

        [HttpGet("GetCharity")]
        public async Task<IActionResult> GetCharity(int charityId, int? userId)
        {
            var data = await _charitiesServices.GetCharity(charityId, userId);
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

        [HttpGet("GetAllCharities")]
        public async Task<IActionResult> GetAllCharities(int causeId, string? leadership, int? userId)
        {
            var data = await _charitiesServices.GetAllCharities(causeId, leadership, userId);
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

        [HttpGet("GetAllLeadership")]
        public async Task<IActionResult> GetAllLeadership()
        {
            var data = await _charitiesServices.GetAllLeadership();
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

        [HttpGet("GetVettingCriterias")]
        public async Task<IActionResult> GetVettingCriterias(int charityId)
        {
            var data = await _charitiesServices.GetVettingCriterias(charityId);
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

        [HttpPost("Donation")]
        public async Task<IActionResult> Donation(DonationRequest donationRequest)
        {
            var data = await _charitiesServices.Donation(donationRequest);
            if (!data.Success)
            {
                return StatusCode(500, new ServiceResponse { Message = "Exception thrown." });
            }
            else if (data.Payload == null)
            {
                return NotFound(data);
            }

            return Ok(new ServiceResponse { Success = true, Message = "Donation successful" });
        }

        [HttpGet("DonationHistory")]
        public async Task<IActionResult> DonationHistory(int userId)
        {
            var data = await _charitiesServices.DonationHistory(userId);
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

        [HttpPost("AddToFavorites")]
        public async Task<IActionResult> AddToFavorites(AddToFavoritesRequest addToFavoritesRequest)
        {
            var data = await _charitiesServices.AddToFavorites(addToFavoritesRequest);
            if (!data.Success)
            {
                return StatusCode(500, new ServiceResponse { Message = "Exception thrown." });
            }
            else if (data.Payload == null)
            {
                return NotFound(data);
            }

            return Ok(new ServiceResponse { Success = true, Message = data.Message });
        }

        [HttpGet("FavoriteCharities")]
        public async Task<IActionResult> FavoriteCharities(int userId)
        {
            var data = await _charitiesServices.FavoriteCharities(userId);
            if (!data.Success)
            {
                return StatusCode(500, new ServiceResponse { Message = "Exception thrown." });
            }

            return Ok(data);
        }

        [HttpGet("DashboardDetails")]
        public async Task<IActionResult> DashboardDetails(int userId)
        {
            var data = await _charitiesServices.DashboardDetails(userId);
            if (!data.Success)
            {
                return StatusCode(500, new ServiceResponse { Message = "Exception thrown." });
            }

            return Ok(data);
        }

        [HttpGet("GetVisitorCounts")]
        public async Task<IActionResult> GetVisitorCounts()
        {
            var data = await _charitiesServices.GetVisitorCounts();
            if (!data.Success)
            {
                return StatusCode(500, new ServiceResponse { Message = "Exception thrown." });
            }

            return Ok(data.Payload);
        }
    }
}
