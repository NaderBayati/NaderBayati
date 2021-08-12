using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NobatOnline.Areas.Makeuper.Models
{
    public class ListCityModel
    {
        public ListCityModel()
        {
            List = new List<ListCityItemModel>();
        }
        public List<ListCityItemModel> List { get; set; }
    }
    public class ListCityItemModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProvinceName { get; set; }
    }
}
