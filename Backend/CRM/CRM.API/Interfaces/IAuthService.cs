using CRM.API.DTOs;
using CRM.API.Helpers;

namespace CRM.API.Interfaces
{
    public interface IAuthService
    {
        AuthResponse Register(RegisterDto dto);
        AuthResponse Login(LoginDto dto);
    }
}
