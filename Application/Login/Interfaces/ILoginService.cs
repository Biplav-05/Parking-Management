using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Login.Interfaces
{
    public interface ILoginService
    {
        Task<string> Login(string email);
    }
}