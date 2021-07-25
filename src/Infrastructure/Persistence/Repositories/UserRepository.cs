using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using CleanArchitecture.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Persistence.Repositories
{
    public class UserRepository : EFRepository<User, long>, IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(UserManager<ApplicationUser> userManager, ILogger<UserRepository> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        public async ValueTask<bool> CreateAsync(User user, string password)
        {
            var result = await _userManager.CreateAsync(new ApplicationUser { UserName = user.UserName }, password);
            if (result.Succeeded)
            {
                _logger.LogInformation("User created a new account with password.");
                return true;
            }

            _logger.LogInformation($"User account creation has failed. {result.Errors}");

            return false;
        }
    }
}
