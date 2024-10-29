using Azure.Core;
using DigitalLibrary.WebApi.Dtos;
using DigitalLibrary.WebApi.Literals;
using DigitalLibrary.WebApi.Repositories.Contracts;
using DigitalLibrary.WebApi.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DigitalLibrary.WebApi.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserRepository _userRepository;
        public UserService(UserManager<IdentityUser> userManager, IUserRepository userRepository)
        {
            _userManager = userManager;
            _userRepository = userRepository;
        }

        public async Task<AuthResponseDto> AddUserAsync(RegisterRequestDto request)
        {
            var response = new AuthResponseDto();
            try
            {
                var result = await _userRepository.AddUser(request);
                if (result != null) 
                {
                    response.IsSuccess = result.Succeeded;
                    response.Errors = result?.Errors?.Select(x => x.Description).ToArray() ?? new string[] { };
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Errors = new string[] { ex.Message };
            }
            return response;
        }

        public async Task<AuthResponseDto> Login(LoginRequestDto request)
        {
            var response = new AuthResponseDto();
            try
            {
                var user = await _userManager.FindByNameAsync(request.UserName);
                if (user != null && await _userManager.CheckPasswordAsync(user, request.Password))
                {
                    var claims = new[]
                    {
                    new Claim(ClaimTypes.Name, user.UserName)
                };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable(DigitalLibraryLiterals.JWT_KEY)));
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(
                        claims: claims,
                        expires: DateTime.Now.AddMinutes(15),
                        signingCredentials: creds
                    );


                    var tokenresult = new JwtSecurityTokenHandler().WriteToken(token);
                    response.Token = tokenresult;
                    response.Expiration = token.ValidTo;
                    response.IsSuccess = true;
                }
                else
                {
                    response.IsSuccess = false;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Errors = new string[] { ex.Message };
            }
            return response;
        }

        public async Task<AuthResponseDto> RefreshToken(string email)
        {
            var response = new AuthResponseDto();
            try
            {
                var user = await _userManager.FindByNameAsync(email);
                if (user != null)
                {
                    var claims = new[]
                    {
                    new Claim(ClaimTypes.Name, user.UserName)
                };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable(DigitalLibraryLiterals.JWT_KEY)));
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(
                        claims: claims,
                        expires: DateTime.Now.AddMinutes(15),
                        signingCredentials: creds
                    );


                    var tokenresult = new JwtSecurityTokenHandler().WriteToken(token);
                    response.Token = tokenresult;
                    response.Expiration = token.ValidTo;
                    response.IsSuccess = true;
                }
                else
                {
                    response.IsSuccess = false;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Errors = new string[] { ex.Message };
            }
            return response;
        }

    }
}
