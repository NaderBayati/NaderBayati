using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domains
{
    public class CustumerTicket
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }
        public int WorkId { get; set; }
        public Work Work { get; set; }
        public DateTime ReserveDate { get; set; }
        public int WorkPrice { get; set; }


    }
}
