using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Models;
using Microsoft.AspNetCore.Authorization;


namespace Project.Controllers
{   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        
        [HttpGet]
        public IEnumerable<Information> Get()
        {
            Information Data1 = new Information() { age = 22, name = "Jaineet" };
            Information Data2 = new Information() { age = 23, name = "Jaineet2" };
            Information Data3 = new Information() { age = 24, name = "Jaineet3" };
            Information Data4 = new Information() { age = 25, name = "Jaineet4" };
            Information Data5 = new Information() { age = 26, name = "Jaineet5" };
            Information Data6 = new Information() { age = 27, name = "Jaineet6" };
            Information Data7 = new Information() { age = 28, name = "Jaineet7" };


            List<Information> L1 = new List<Information> ();
            L1.Add(Data1);
            L1.Add(Data2);
            L1.Add(Data3);
            L1.Add(Data4);
            L1.Add(Data5);
            L1.Add(Data6);
            L1.Add(Data7);

            return L1;

        }

        [HttpGet("{id}")]
        public IEnumerable<Information> Get(string Id)
        {
            int Ageid = Convert.ToInt32(Id);
            return new List<Information>
            {
                new Information { age = 22, name = "Jaineet" },
                new Information { age = 23, name = "Jaineet2" },
                new Information { age = 24, name = "Jaineet3" },
                new Information { age = 25, name = "Jaineet4" },
                new Information { age = 26, name = "Jaineet5" },
                new Information { age = 27, name = "Jaineet6" },
                 new Information { age = 28, name = "Jaineet7" } }.Where(s => s.age == Ageid);
                

                }


    }
}
