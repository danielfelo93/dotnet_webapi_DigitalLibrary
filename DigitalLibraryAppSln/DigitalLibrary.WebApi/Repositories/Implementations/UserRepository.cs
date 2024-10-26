using DigitalLibrary.WebApi.Dtos;
using DigitalLibrary.WebApi.Models;
using DigitalLibrary.WebApi.Repositories.Contracts;
using Microsoft.AspNetCore.Identity;
using System.Transactions;

namespace DigitalLibrary.WebApi.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly DigitalLibraryAppDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public UserRepository(DigitalLibraryAppDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IdentityResult> AddUser(RegisterRequestDto request)
        {
            var response = new IdentityResult();
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var user = new ApplicationUser
                {
                    UserName = request.Email.ToLower(),
                    Email = request.Email,
                };

                var result = await _userManager.CreateAsync(user, request.Password);
                response = result;

                if (!result.Succeeded)
                {
                    return response;
                }

                var newUser = new User
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    AspNetUserId = user.Id
                };
                await _context.Users.AddAsync(newUser);
                await _context.SaveChangesAsync();
                scope.Complete();
            }
            //var result = await _userManager.CreateAsync(user, model.Password);
            return response;
        }
    }
}
