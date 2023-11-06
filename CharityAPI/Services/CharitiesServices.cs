using CharityAPI.Entities;
using CharityAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;

namespace CharityAPI.Services
{
    public class CharitiesServices : ICharitiesServices
    {
        private readonly CharityDbContext _context;
        public CharitiesServices(CharityDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse> GetCharity(int charityId, int? userId)
        {
            try
            {
                var charityResponse = new CharitiesResponse();
                var data = new CausesCharities();

                if (userId == null)
                {
                    data = await _context.CausesCharities.Include(x => x.Cause).Include(x => x.Charity.Impacts)
                    .Where(x => x.Charity.Id == charityId).FirstOrDefaultAsync();
                }
                else
                {
                    data = await _context.CausesCharities.Include(x => x.Cause).Include(x => x.Charity.Impacts).Include(x => x.Charity.Favorites)
                    .Where(x => x.Charity.Id == charityId).FirstOrDefaultAsync();
                }


                if (data != null)
                {
                    charityResponse.Id = data.Id;
                    charityResponse.Name = data.Charity.Name;
                    charityResponse.Description = data.Charity.Description;
                    charityResponse.PhoneNumber = data.Charity.PhoneNumber;
                    charityResponse.Mail = data.Charity.Mail;
                    charityResponse.TargetGroup = data.Charity.TargetGroup;
                    charityResponse.CauseId = data.Cause.Id;
                    charityResponse.CauseName = data.Cause.Name;
                    charityResponse.Leadership = data.Charity.Leadership;
                    charityResponse.LeadershipDescription = data.Charity.LeadershipDescription;
                    charityResponse.Website = data.Charity.Website;
                    charityResponse.Financials = data.Charity.Financials;
                    charityResponse.AnnualReportLink = data.Charity.AnnualReportLink;
                    charityResponse.ImageUrl = data.Charity.ImageUrl;
                    charityResponse.Vetted = data.Charity.Vetted;
                    charityResponse.IsFeatured = data.Charity.IsFeatured;
                    charityResponse.Efficiency = data.Charity.Efficiency;
                    charityResponse.SocialResponsibilityRating = data.Charity.SocialResponsibilityRating;
                    charityResponse.NumFavorites = data.Charity.NumFavorites;
                    charityResponse.TotalIncome = data.Charity.TotalIncome;
                    charityResponse.Spendings = data.Charity.Spendings;
                    charityResponse.DonationLink = data.Charity.DonationLink;

                    if (userId != null)
                    {
                        var favoritesData = data.Charity.Favorites.Where(x => x.UserId == userId && x.CharityId == data.Id).FirstOrDefault();
                        if (favoritesData != null)
                        {
                            charityResponse.IsFavorite = true;
                        }
                    }

                    if (data.Charity.Impacts.Count > 0)
                    {
                        foreach (var item in data.Charity.Impacts)
                        {
                            var impactsResponse = new ImpactsResponse
                            {
                                Id = item.Id,
                                Description = item.Description
                            };

                            charityResponse.Impacts.Add(impactsResponse);
                        }
                    }
                }

                return new ServiceResponse
                {
                    Success = true,
                    Message = "Data fetching successful.",
                    Payload = charityResponse
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
        public async Task<ServiceResponse> GetAllCharities(int causeId, string? leadership, int? userId)
        {
            try
            {
                var charityList = new List<CharitiesResponse>();
                var data = new List<CausesCharities>();

                if (userId == null)
                {
                    data = await _context.CausesCharities.Include(x => x.Cause).Include(x => x.Charity)
                    .Where(leadership == null ? (x => x.CauseId == causeId) :
                    (x => x.CauseId == causeId && x.Charity.Leadership == leadership)).ToListAsync();
                }
                else
                {
                    data = await _context.CausesCharities.Include(x => x.Cause).Include(x => x.Charity.Favorites)
                    .Where(leadership == null ? (x => x.CauseId == causeId) :
                    (x => x.CauseId == causeId && x.Charity.Leadership == leadership)).ToListAsync();
                }


                foreach (var item in data)
                {
                    var charitiesResponse = new CharitiesResponse
                    {
                        Id = item.Id,
                        Name = item.Charity.Name,
                        Description = item.Charity.Description,
                        PhoneNumber = item.Charity.PhoneNumber,
                        Mail = item.Charity.Mail,
                        TargetGroup = item.Charity.TargetGroup,
                        CauseId = item.Cause.Id,
                        CauseName = item.Cause.Name,
                        Leadership = item.Charity.Leadership,
                        LeadershipDescription = item.Charity.LeadershipDescription,
                        Website = item.Charity.Website,
                        Financials = item.Charity.Financials,
                        AnnualReportLink = item.Charity.AnnualReportLink,
                        ImageUrl = item.Charity.ImageUrl,
                        Vetted = item.Charity.Vetted,
                        IsFeatured = item.Charity.IsFeatured,
                        Efficiency = item.Charity.Efficiency,
                        SocialResponsibilityRating = item.Charity.SocialResponsibilityRating,
                        NumFavorites = item.Charity.NumFavorites,
                        DonationLink = item.Charity.DonationLink
                    };

                    if (userId != null)
                    {
                        var favoritesData = item.Charity.Favorites.Where(x => x.UserId == userId && x.CharityId == item.Id).FirstOrDefault();
                        if (favoritesData != null)
                        {
                            charitiesResponse.IsFavorite = true;
                        }
                    }

                    charityList.Add(charitiesResponse);
                }

                return new ServiceResponse
                {
                    Success = true,
                    Message = "Data fetching successful.",
                    Payload = charityList
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
        public async Task<ServiceResponse> GetAllLeadership()
        {
            try
            {
                var leadershipList = new List<LeadershipResponse>();
                var response = await _context.Charities.ToListAsync();
                var data = response.DistinctBy(x => x.Leadership);

                foreach (var item in data)
                {
                    var leadershipResponse = new LeadershipResponse
                    {
                        Leadership = item.Leadership
                    };

                    leadershipList.Add(leadershipResponse);
                }

                return new ServiceResponse
                {
                    Success = true,
                    Message = "Data fetching successful.",
                    Payload = leadershipList
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
        public async Task<ServiceResponse> GetVettingCriterias(int charityId)
        {
            try
            {
                var vettingCriteriaList = new List<VettingCriteriaResponse>();
                var data = await _context.CharitiesVettingCriterias.Include(x => x.VettingCriteria.VettingDetails)
                    .Where(x => x.CharityId == charityId).ToListAsync();

                foreach (var item in data)
                {
                    var vettingCriteria = new VettingCriteriaResponse();
                    vettingCriteria.Id = item.VettingCriteriaId;
                    vettingCriteria.Name = item.VettingCriteria.Name;

                    foreach (var itemVd in item.VettingCriteria.VettingDetails)
                    {
                        var vettingDetails = new VettingDetailsResponse();
                        vettingDetails.Id = itemVd.Id;
                        vettingDetails.Name = itemVd.Name;
                        vettingCriteria.VettingDetailsResponse.Add(vettingDetails);
                    }
                    vettingCriteriaList.Add(vettingCriteria);
                }

                return new ServiceResponse
                {
                    Success = true,
                    Message = "Data fetching successful.",
                    Payload = vettingCriteriaList
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
        public async Task<ServiceResponse> Donation(DonationRequest donationRequest)
        {
            try
            {
                var user = await _context.Users.Where(x => x.Id == donationRequest.UserId).FirstOrDefaultAsync();
                if (user == null)
                {
                    return new ServiceResponse
                    {
                        Success = true,
                        Message = "User not found.",
                        Payload = null
                    };
                }

                var charity = await _context.Charities.Where(x => x.Id == donationRequest.CharityId).FirstOrDefaultAsync();
                if (charity == null)
                {
                    return new ServiceResponse
                    {
                        Success = true,
                        Message = "charity not found.",
                        Payload = null
                    };
                }

                if (donationRequest.Amount == 0)
                {
                    return new ServiceResponse
                    {
                        Success = true,
                        Message = "Amount can't be zero.",
                        Payload = null
                    };
                }

                var userCharityDonations = new UserCharityDonations
                {
                    UserId = donationRequest.UserId,
                    CharityId = donationRequest.CharityId,
                    Amount = donationRequest.Amount,
                    DonationDate = DateTime.Now
                };

                await _context.UserCharityDonations.AddAsync(userCharityDonations);
                await _context.SaveChangesAsync();

                return new ServiceResponse
                {
                    Success = true,
                    Message = "Donation successful.",
                    Payload = userCharityDonations
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
        public async Task<ServiceResponse> AddToFavorites(AddToFavoritesRequest addToFavoritesRequest)
        {
            try
            {
                var user = await _context.Users.Where(x => x.Id == addToFavoritesRequest.UserId).FirstOrDefaultAsync();
                if (user == null)
                {
                    return new ServiceResponse
                    {
                        Success = true,
                        Message = "User not found.",
                        Payload = null
                    };
                }

                var charity = await _context.Charities.Where(x => x.Id == addToFavoritesRequest.CharityId).FirstOrDefaultAsync();
                if (charity == null)
                {
                    return new ServiceResponse
                    {
                        Success = true,
                        Message = "charity not found.",
                        Payload = null
                    };
                }

                var userFavorites = await _context.Favorites.Where(x => x.UserId == addToFavoritesRequest.UserId
                && x.CharityId == addToFavoritesRequest.CharityId).FirstOrDefaultAsync();
                if (userFavorites != null)
                {
                    _context.Favorites.Remove(userFavorites);
                    charity.NumFavorites -= 1;
                    _context.SaveChanges();
                    return new ServiceResponse
                    {
                        Success = true,
                        Message = "Successfully removed from favorites",
                        Payload = userFavorites
                    };
                }

                var favorites = new Favorites
                {
                    UserId = addToFavoritesRequest.UserId,
                    CharityId = addToFavoritesRequest.CharityId
                };

                await _context.Favorites.AddAsync(favorites);
                charity.NumFavorites += 1;
                await _context.SaveChangesAsync();

                return new ServiceResponse
                {
                    Success = true,
                    Message = "Successfully added in favorites",
                    Payload = favorites
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
        public async Task<ServiceResponse> DonationHistory(int userId)
        {
            try
            {
                var donationHistoryList = new List<DonationHistoryResponse>();
                var user = await _context.Users.Where(x => x.Id == userId).FirstOrDefaultAsync();
                if (user == null)
                {
                    return new ServiceResponse
                    {
                        Success = true,
                        Message = "User not found.",
                        Payload = null
                    };
                }

                var donationHistory = await _context.UserCharityDonations.Include(x => x.Charity)
                    .Where(x => x.UserId == userId).OrderByDescending(x => x.Id).ToListAsync();

                foreach (var item in donationHistory)
                {
                    var data = new DonationHistoryResponse
                    {
                        DonationId = item.Id,
                        UserId = item.UserId,
                        CharityId = item.CharityId,
                        CharityName = item.Charity.Name,
                        Website = item.Charity.Website,
                        Amount = item.Amount,
                        DonationDate = item.DonationDate
                    };
                    donationHistoryList.Add(data);
                }

                return new ServiceResponse
                {
                    Success = true,
                    Message = "Donation successful.",
                    Payload = donationHistoryList
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
        public async Task<ServiceResponse> FavoriteCharities(int userId)
        {
            try
            {
                var charityList = new List<CharitiesResponse>();
                var data = new List<Favorites>();

                data = await _context.Favorites.Include("Charity.CausesCharities.Cause").Where(x => x.UserId == userId).ToListAsync();
                if (data.Count == 0)
                {
                    return new ServiceResponse
                    {
                        Success = true,
                        Message = "No data found",
                        Payload = charityList
                    };
                }

                foreach (var item in data)
                {
                    var charitiesResponse = new CharitiesResponse
                    {
                        Id = item.Charity.Id,
                        Name = item.Charity.Name,
                        CauseId = item.Charity.CausesCharities.FirstOrDefault().Cause.Id,
                        CauseName = item.Charity.CausesCharities.FirstOrDefault().Cause.Name,
                        Description = item.Charity.Description,
                        PhoneNumber = item.Charity.PhoneNumber,
                        Mail = item.Charity.Mail,
                        TargetGroup = item.Charity.TargetGroup,
                        Leadership = item.Charity.Leadership,
                        LeadershipDescription = item.Charity.LeadershipDescription,
                        Website = item.Charity.Website,
                        Financials = item.Charity.Financials,
                        AnnualReportLink = item.Charity.AnnualReportLink,
                        ImageUrl = item.Charity.ImageUrl,
                        Vetted = item.Charity.Vetted,
                        IsFeatured = item.Charity.IsFeatured,
                        Efficiency = item.Charity.Efficiency,
                        SocialResponsibilityRating = item.Charity.SocialResponsibilityRating,
                        NumFavorites = item.Charity.NumFavorites,
                        DonationLink = item.Charity.DonationLink,
                        TotalIncome = item.Charity.TotalIncome,
                        Spendings = item.Charity.Spendings
                    };

                    var favoritesData = item.Charity.Favorites.Where(x => x.UserId == userId && x.CharityId == item.Id).FirstOrDefault();
                    if (favoritesData != null)
                    {
                        charitiesResponse.IsFavorite = true;
                    }

                    charityList.Add(charitiesResponse);
                }

                return new ServiceResponse
                {
                    Success = true,
                    Message = "Data fetching successful.",
                    Payload = charityList
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
        public async Task<ServiceResponse> DashboardDetails(int userId)
        {
            try
            {
                var dashboardDetails = new DashboardDetailsResponse();
                var user = await _context.Users.Where(x => x.Id == userId).FirstOrDefaultAsync();
                if (user == null)
                {
                    return new ServiceResponse
                    {
                        Success = true,
                        Message = "User not found.",
                        Payload = null
                    };
                }

                var donationHistory = await _context.UserCharityDonations
                    .Where(x => x.UserId == userId).ToListAsync();
                var favorites = await _context.Favorites.Where(x => x.UserId == userId).ToListAsync();

                dashboardDetails.TotalDonations = donationHistory.Count == 0 ? 0 : donationHistory.Sum(x => x.Amount);
                dashboardDetails.FavoriteCharityCount = favorites.Count;

                return new ServiceResponse
                {
                    Success = true,
                    Message = "Data fatch successful.",
                    Payload = dashboardDetails
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
        public async Task<ServiceResponse> GetVisitorCounts()
        {
            try
            {
                var dashboardDetails = new DashboardDetailsResponse();
                var data = await _context.VisitorCounts.FirstOrDefaultAsync();
                if (data == null)
                {
                    var VisitorCounts = new VisitorCounts
                    {
                        NumberOfVisits = 1,
                    };

                    await _context.VisitorCounts.AddAsync(VisitorCounts);
                    await _context.SaveChangesAsync();

                    return new ServiceResponse
                    {
                        Success = true,
                        Message = "Data fetching successful.",
                        Payload = VisitorCounts
                    };
                }

                data.NumberOfVisits += 1;
                await _context.SaveChangesAsync();

                return new ServiceResponse
                {
                    Success = true,
                    Message = "Data fatch successful.",
                    Payload = data
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

    public interface ICharitiesServices
    {
        Task<ServiceResponse> GetCharity(int charityId, int? userId);
        Task<ServiceResponse> GetAllCharities(int causeId, string? leadership, int? userId);
        Task<ServiceResponse> GetAllLeadership();
        Task<ServiceResponse> GetVettingCriterias(int charityId);
        Task<ServiceResponse> Donation(DonationRequest donationRequest);
        Task<ServiceResponse> DonationHistory(int userId);
        Task<ServiceResponse> AddToFavorites(AddToFavoritesRequest addToFavoritesRequest);
        Task<ServiceResponse> FavoriteCharities(int userId);
        Task<ServiceResponse> DashboardDetails(int userId);
        Task<ServiceResponse> GetVisitorCounts();
    }
}
