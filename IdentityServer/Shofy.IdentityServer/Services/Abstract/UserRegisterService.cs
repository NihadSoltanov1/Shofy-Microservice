using Microsoft.AspNetCore.Identity;
using Shofy.IdentityServer.Dtos;
using Shofy.IdentityServer.Models;
using Shofy.IdentityServer.Services.Interfaces;
using System.Threading.Tasks;

namespace Shofy.IdentityServer.Services.Abstract
{
    public class UserRegisterService : IUserRegisterService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserRegisterService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> AddUser(UserRegisterDto user)
        {
            var values = new ApplicationUser()
            {
                UserName = user.Username,
                Email = user.Email,
                Name = user.Name,
                Surname = user.Surname
            };
            var result = await _userManager.CreateAsync(values, user.Password);
            return result.Succeeded;
        }
    }
}
