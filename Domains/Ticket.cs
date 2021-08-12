using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domains
{
    public class Ticket
    {
        public int Id { get; set; }
        public int BeautyId { get; set; }
        public Beauty Beauty { get; set; }
        public DateTime Date { get; set; }
        public string DayName { get; set; }
        public string Time { get; set; }
        public ICollection<CustumerTicket> CustumerTickets { get; set; }
    }
}
