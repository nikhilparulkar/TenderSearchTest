using System;
using System.Collections.Generic;

namespace TenderSearchTest.DBAccess
{
    public partial class TenderDetails
    {
        public int UserId { get; set; }
        public int ReferenceNumber { get; set; }
        public string Name { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public DateTime? ClosingDate { get; set; }

        public User User { get; set; }
    }
}
