using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Application.Login.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ParkingApi.Controllers
{
    [Route("[controller]")]
    public class AccessController : Controller
    {
         private readonly ILoginService _loginService;
         public AccessController(ILoginService loginService)
         {
            _loginService = loginService;
         }
        [HttpGet]
        [Route("api/login")]
        public async Task<IActionResult> Login()
        {
            var response = await _loginService.Login("biplav@gmail.com");
            return Ok(response);
        }
    }
}