using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenderSearchTest.Models;

namespace TenderSearchTest.Services
{
    public interface IUserToken
    {
        string GenerateToken(string UserName);

        bool UserExists(UserLogin user);
    }
}
