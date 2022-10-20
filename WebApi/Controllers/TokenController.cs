using Entities.DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.JwtAuthorizeToken.Abstract;

namespace WebApi.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IAuthService service;
        public TokenController(IAuthService _service)
        {
            service = _service;
        }
        [HttpPost]
        public IActionResult Post(UserApiLoginDto user)
        {
            var Token = service.Authenticate(user.EPosta,user.Password);
            if (Token == null)
            {
                return BadRequest(Token);
            }
            else
            {
                return Ok(Token);
            }
        }
    }
}
