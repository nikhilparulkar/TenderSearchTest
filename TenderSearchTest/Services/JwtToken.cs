using JWT.Algorithms;
using JWT.Builder;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace TenderSearchTest.Services
{
    public static class JwtToken
    {


        /// <summary>
        /// Use the below code to generate symmetric Secret Key
        ///     var hmac = new HMACSHA256();
        ///     var key = Convert.ToBase64String(hmac.Key);
        /// </summary>
        public const string Secret = "db3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWG4HnV8TZY30iTOdtVWJG8abWvB1GlOgJuQZdcF2Luqm/hccMw==";

        public static string GenerateAccessToken(string username, int expireMinutes = 20)
        {
            
            var token = new JwtBuilder()
                                  .WithAlgorithm(new HMACSHA256Algorithm())
                                  .WithSecret(Secret)
                                  .AddClaim("exp", DateTimeOffset.UtcNow.AddMinutes(expireMinutes).ToUnixTimeSeconds())
                                  .AddClaim("email", username)
                                  .Build();

            Console.WriteLine(token);

            return token;
        }



    }


}
