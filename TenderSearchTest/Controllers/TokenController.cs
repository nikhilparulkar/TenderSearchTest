using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TenderSearchTest.Filters;
using TenderSearchTest.Models;
using TenderSearchTest.Services;

namespace TenderSearchTest.Controllers
{

    
    public class TokenController : ControllerBase
    {
        private IUserToken _ud;
        public TokenController(IUserToken svc)
        {
            _ud = svc;
        }
        // GET api/values
        [HttpGet,Route ("AccessToken")]
        
        public IActionResult Get([FromBody]JObject user )
        {
            var temp = JsonConvert.DeserializeObject<UserLogin>(user.ToString());

           if (_ud.UserExists(temp))
           {
                return Ok(_ud.GenerateToken(temp.userName));
           }
            else
            {
                return NotFound();
            }
        }

        
    }
}
