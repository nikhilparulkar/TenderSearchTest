using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TenderSearchTest.DBAccess;
using TenderSearchTest.Filters;
using TenderSearchTest.Models;

namespace TenderSearchTest.Controllers
{
    [JWTAuthenticate]
    public class TenderDetailsController : Controller

    {

        TenderContext db = new TenderContext();

        [HttpGet, Route("tenders")]
        public IActionResult ListAllTenderforUser( string user)
        {
            var uid = db.User.Where(x => x.Email == user).FirstOrDefault().UserId;

            var TList = db.TenderDetails.Where(x => x.UserId == uid)
                                        .Select( x => new {User =user,
                                                    ReleaseDate = x.ReleaseDate,
                                                    ClosingDate = x.ClosingDate,
                                                    Name = x.Name,
                                                    ReferenceName = x.ReferenceNumber}
                                               )
                                       .ToList();
            return Ok(JsonConvert.SerializeObject(TList));
        }

        [HttpPut, Route("tenders/Modify")]
        public IActionResult ModifyTenderDetails([FromBody]JObject body)
        {
            var tmd = JsonConvert.DeserializeObject<TenderDetailRequest>(body.ToString());
            var uid = db.User.Where(x => x.Email == tmd.User).FirstOrDefault().UserId;
            var td = db.TenderDetails.Where(x => x.UserId == uid && x.ReferenceNumber == tmd.referenceNumber).FirstOrDefault();
            if (td != null)
            {

                td.Name = tmd.name;
                td.ReleaseDate = tmd.ReleaseDate;
                td.ClosingDate = tmd.ClosingDate;
                db.Update(td);
                db.SaveChanges();

                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete, Route("tenders/delete")] 
        public IActionResult DeleteTenderDetails([FromBody]JObject body)
        {
            var tmd = JsonConvert.DeserializeObject<TenderDetailRequest>(body.ToString());
            var uid = db.User.Where(x => x.Email == tmd.User).FirstOrDefault().UserId;
            var td = db.TenderDetails.Where(x => x.UserId == uid && x.ReferenceNumber == tmd.referenceNumber).FirstOrDefault();
            if (td != null)
            {
                db.Remove(td);
                db.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost, Route("tenders/add")]
        public IActionResult AddNewTender([FromBody]JObject body)
        {
            var td = JsonConvert.DeserializeObject<TenderDetailRequest>(body.ToString());
            var existingUser= db.User.Where(x => x.Email == td.User).FirstOrDefault();
            var newTD = new TenderDetails
            {
                Name = td.name,
                ReleaseDate = td.ReleaseDate,
                ClosingDate = td.ClosingDate,
                ReferenceNumber = td.referenceNumber,
                UserId = existingUser.UserId,
                User = existingUser
            };
            db.Add(newTD);
            db.SaveChanges();
            return Ok();
        }



    }
}