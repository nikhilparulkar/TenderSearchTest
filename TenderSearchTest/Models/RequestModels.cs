using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TenderSearchTest.Models
{
    public class UserLogin
    {
        public string userName { get; set; }
        public String passwd { get; set; }
    }

    public class TenderDetailsTenderModifyRequest
    {
        public string userName { get; set; }
        public int referenceNumber { get; set; }
    }

    public class TenderDetailRequest
    {
        public String User { get; set; }
        public int referenceNumber { get; set; }
        public string name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime ClosingDate { get; set; }
        

    }

    public class JWTClaims
    {
        public string exp { get; set; }
        public String username { get; set; }
    }
}
