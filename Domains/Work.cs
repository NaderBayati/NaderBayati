using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domains
{
    public class Work
    {
        public int Id { get; set; }
        public string Onvan { get; set; }
        public int Price { get; set; }
        public int BeautyId { get; set; }
        public Beauty Beauty { get; set; }
        public ICollection<CustumerTicket> CustumerTickets { get; set; }
    }
}
