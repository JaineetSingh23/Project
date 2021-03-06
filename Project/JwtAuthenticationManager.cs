using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {
        private readonly string key="this is my key";
        
        private readonly IDictionary<string, string> users = 
            new Dictionary<string, string>
        {  {"Jaineet", "Pass" }   ,  {"Jaineet2","Pass2" }   }  ;
        
       public JwtAuthenticationManager( string key)
        {
            this.key = key;
        }    

        public string Authenticate ( string username , string password)
        {
             if(!users.Any(u => u.Key == username && u.Value == password))
            {
                return null;

            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenkey = Encoding.ASCII.GetBytes(key);
            var tokendescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)

                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256Signature)


            };
            var token = tokenHandler.CreateToken(tokendescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
