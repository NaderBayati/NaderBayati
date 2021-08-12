using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domains
{
    public class BeautyImage
    {
        public int Id { get; set; }
        public int BeautyId { get; set; }
        public Beauty Beauty { get; set; }
        public string Image { get; set; }
    }
}
