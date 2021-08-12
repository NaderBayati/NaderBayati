using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domains
{
    public class AppUser:IdentityUser<int>
    {
        public string CodeMeli { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageProfile { get; set; }
        public ICollection<Beauty> Beauties { get; set; }
        public ICollection<CustumerTicket> CustumerTickets { get; set; }
        public bool Active { get; set; }
    }
    public class AppRole:IdentityRole<int>
    {

    }
}
