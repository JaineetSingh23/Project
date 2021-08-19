using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Project.Controllers
{ 
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NameController : ControllerBase
    {
        private readonly IJwtAuthenticationManager jwtAuthenticationManager;
        public NameController(IJwtAuthenticationManager jwtAuthenticationManager)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Jaineet From Name API ", "Jaineet 2 From Name API" };
        }


        [AllowAnonymous]
        [HttpPost ("authenicate")]
        public IActionResult Authenticate ([FromBody] UserCred usercred)
        {
           var token =   jwtAuthenticationManager.Authenticate(usercred.Username, usercred.Password);
            if( token == null )
            {

                return Unauthorized();
            }
            return Ok(token);
        }
      
    }
}
