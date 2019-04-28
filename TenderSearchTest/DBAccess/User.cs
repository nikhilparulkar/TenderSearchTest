using System;
using System.Collections.Generic;

namespace TenderSearchTest.DBAccess
{
    public partial class User
    {
        public User()
        {
            TenderDetails = new HashSet<TenderDetails>();
        }

        public int UserId { get; set; }
        public string Email { get; set; }
        public string Passwd { get; set; }

        public ICollection<TenderDetails> TenderDetails { get; set; }
    }
}
