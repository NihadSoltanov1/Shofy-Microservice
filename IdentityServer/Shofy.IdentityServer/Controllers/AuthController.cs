using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Shofy.IdentityServer.Dtos;
using Shofy.IdentityServer.Services.Interfaces;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace Shofy.IdentityServer.Controllers
{
    [Authorize(LocalApi.PolicyName)]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRegisterService _userRegister;

        public AuthController(IUserRegisterService userRegister)
        {
            _userRegister = userRegister;
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterDto userRegisterDto)
        {
            var result = await _userRegister.AddUser(userRegisterDto);
            return result ? Ok("User added successfully") : Ok("Error");
        }
    }
}
