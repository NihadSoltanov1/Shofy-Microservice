using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Shofy.IdentityServer.Dtos;
using Shofy.IdentityServer.Services.Interfaces;
using System.Threading.Tasks;

namespace Shofy.IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private readonly IUserRegisterService _userRegister;

        public RegistersController(IUserRegisterService userRegister)
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
