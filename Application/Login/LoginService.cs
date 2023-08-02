using Application.Login.Interfaces;

namespace Application.Login
{
    public class LoginService : ILoginService
    {
        public async Task<string> Login(string email)
        {
            return email;
        }
    }
}