using Shofy.IdentityServer.Dtos;
using System.Threading.Tasks;

namespace Shofy.IdentityServer.Services.Interfaces
{
    public interface IUserRegisterService
    {
        Task<bool> AddUser(UserRegisterDto user);
    }
}
