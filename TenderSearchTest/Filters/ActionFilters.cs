using JWT;
using JWT.Builder;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenderSearchTest.DBAccess;
using TenderSearchTest.Models;
using TenderSearchTest.Services;

namespace TenderSearchTest.Filters
{
    public class JWTAuthenticate : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var db = new TenderContext();
           
           var token =  context.HttpContext.Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value;

            try
            {
                var json = new JwtBuilder()
                    .WithSecret(JwtToken.Secret)
                    .MustVerifySignature()
                    .Decode(token);

                var jwtclaims = JsonConvert.DeserializeObject<JWTClaims>(json);

                if (jwtclaims != null)
                {
                    var user = db.User.Where(x => x.Email == jwtclaims.username).FirstOrDefault();
                    if (user == null)
                        throw new TokenExpiredException("invalid token");


                }
                else
                {

                    throw new TokenExpiredException("invalid token");
                }

            }
            catch (TokenExpiredException)
            {
                Console.WriteLine("Token has expired");
            }
            catch (SignatureVerificationException)
            {
                Console.WriteLine("Token has invalid signature");
            }
        }

    }
}
