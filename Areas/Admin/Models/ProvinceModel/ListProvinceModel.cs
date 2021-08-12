using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NobatOnline.Areas.Admin.Models
{
    public class ListProvinceModel
    {
        public ListProvinceModel()
        {
            List = new List<ListProvinceItemModel>();
        }
        public List<ListProvinceItemModel> List { get; set; }
    }
    public class ListProvinceItemModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
