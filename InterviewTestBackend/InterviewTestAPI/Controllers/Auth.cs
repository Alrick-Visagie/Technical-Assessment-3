using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Models;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InterviewTestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Auth : ControllerBase
    {
        private readonly AuthService _authService;

        public Auth(AuthService authService)
        {
            this._authService = authService;
        }

        [HttpPost()]
        public async Task<IActionResult> Login(LoginModel model)
        {
            try
            {
                var token = await _authService.Login(model);
                return Ok(token);
            } catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
 