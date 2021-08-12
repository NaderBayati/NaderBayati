using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NobatOnline.Areas.Admin.Models
{
    public class ListMakeuperModel
    {
        public ListMakeuperModel()
        {
            List = new List<ListMakeuperItemModel>();
        }
        public List<ListMakeuperItemModel> List { get; set; }
    }
    public class ListMakeuperItemModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string IsActive { get; set; }
    }
}
