using DigitalLibrary.WebApi.Dtos;
using Microsoft.AspNetCore.Identity;

namespace DigitalLibrary.WebApi.Repositories.Contracts
{
    public interface IUserRepository
    {
        Task<IdentityResult> AddUser(RegisterRequestDto request);
    }
}
