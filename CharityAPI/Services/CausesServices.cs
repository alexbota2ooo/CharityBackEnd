using CharityAPI.Entities;
using CharityAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace CharityAPI.Services
{
    public class CausesServices : ICausesServices
    {
        private readonly CharityDbContext _context;
        public CausesServices(CharityDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse> GetAllCauses(int count)
        {
            try
            {
                var data = new List<Causes>();
                var responseData = new List<CausesResponse>();

                if (count == 0)
                {
                    data = await _context.Causes.Include(x => x.CausesCharities)
                        .OrderByDescending(x => x.CausesCharities.Count()).ToListAsync();
                }
                else
                {
                    data = await _context.Causes.Include(x => x.CausesCharities)
                        .OrderByDescending(x => x.CausesCharities.Count()).Take(count).ToListAsync();
                }

                foreach (var item in data)
                {
                    var CausesResponse = new CausesResponse
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Description = item.Description,
                        ImageUrl = item.ImageUrl,
                        CharityCount = item.CausesCharities.Count
                    };

                    responseData.Add(CausesResponse);
                }

                return new ServiceResponse
                {
                    Success = true,
                    Message = "Data fetching successful.",
                    Payload = responseData
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse
                {
                    Success = false,
                    Message = "Exception Thrown",
                    Payload = null
                };
            }
        }
    }

    public interface ICausesServices
    {
        Task<ServiceResponse> GetAllCauses(int count);
    }
}
