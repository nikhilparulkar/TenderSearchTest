using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenderSearchTest.DBAccess;
using TenderSearchTest.Models;

namespace TenderSearchTest.Services
{
    public class UserToken : IUserToken
    {
        TenderContext Db = new TenderContext();
        public bool UserExists(UserLogin u)
        {
            var res = Db.User.Where(x => x.Email == u.userName && x.Passwd == u.passwd).FirstOrDefault();
            return (res==null ? false:true);
        }

        public string GenerateToken(string UserName)
        {
            return JwtToken.GenerateAccessToken(UserName);
        }
    }
}
