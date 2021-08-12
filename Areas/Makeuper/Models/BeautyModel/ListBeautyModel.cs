using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NobatOnline.Areas.Makeuper.Models
{
    public class ListBeautyModel
    {
        public ListBeautyModel()
        {
            List = new List<ListBeautyItemModel>();
        }
        public List<ListBeautyItemModel> List { get; set; }
    }
    public class ListBeautyItemModel
    {
        public int Id { get; set; }
        public string BeautyName { get; set; }
        public string CityName { get; set; }
    
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
