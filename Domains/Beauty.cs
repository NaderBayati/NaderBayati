using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domains
{
    public class Beauty
    {
        public int Id { get; set; }
        public string BeautyName { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public ICollection<BeautyImage> BeautyImages { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
        public ICollection<Work> Works { get; set; }
    }
}
