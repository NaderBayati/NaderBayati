using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NobatOnline.Areas.Customer.Models
{
    public class ListCustomerModel
    {
        public ListCustomerModel()
        {
            List = new List<ListCustomerItemModel>();
        }
        public List<ListCustomerItemModel> List { get; set; }
    }
    public class ListCustomerItemModel
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
