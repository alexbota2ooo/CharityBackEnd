using CharityAPI.Entities;
using CharityAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace CharityAPI.Services
{
    public class SignInServices : ISignInServices
    {
        private readonly CharityDbContext _context;
        private readonly IConfiguration _configuration;
        public SignInServices(CharityDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<ServiceResponse> UserSignIn(SignInRequest oSignIn)
        {
            try
            {
                var data = await _context.Users.Where(x => x.Email.ToLower() == oSignIn.Email.ToLower()
                && x.Password.ToLower() == oSignIn.Password.ToLower()).FirstOrDefaultAsync();

                if (data == null)
                {
                    return new ServiceResponse
                    {
                        Success = true,
                        Message = "User not found.",
                        Payload = null
                    };
                }

                SignInResponse signInResponse = new SignInResponse()
                {
                    Id = data.Id,
                    Name = data.Name,
                    Email = data.Email,
                    Role = data.Role
                };

                return new ServiceResponse
                {
                    Success = true,
                    Message = _configuration.GetValue<string>("XApiKey"),
                    Payload = signInResponse
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse
                {
                    Success = false,
                    Message = "Exception Thrown. " + ex.Message,
                    Payload = null
                };
            }
        }

        public async Task<ServiceResponse> UserSignUp(SignUpRequest oSignUp)
        {
            try
            {
                if (!IsValidEmail(oSignUp.Email))
                {
                    return new ServiceResponse
                    {
                        Success = true,
                        Message = "Please provide a valid email.",
                        Payload = new SignUpResponse()
                    };
                }
                var data = await _context.Users.Where(x => x.Email.ToLower() == oSignUp.Email.ToLower()).FirstOrDefaultAsync();
                if (data != null)
                {
                    return new ServiceResponse
                    {
                        Success = true,
                        Message = "Email already exists.",
                        Payload = new SignUpResponse()
                    };
                }

                var user = new Users
                {
                    Name = oSignUp.UserName,
                    Email = oSignUp.Email,
                    Password = oSignUp.Password,
                    Role = "user"
                };
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();

                SignUpResponse signUpResponse = new SignUpResponse()
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    Role = user.Role
                };

                return new ServiceResponse
                {
                    Success = true,
                    Message = "Registration successfull",
                    Payload = signUpResponse
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse
                {
                    Success = false,
                    Message = "Exception Thrown. " + ex.Message,
                    Payload = null
                };
            }
        }

        bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false; // suggested by @TK-421
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }
    }


    public interface ISignInServices
    {
        Task<ServiceResponse> UserSignIn(SignInRequest oSignIn);
        Task<ServiceResponse> UserSignUp(SignUpRequest oSignUp);
    }
}
