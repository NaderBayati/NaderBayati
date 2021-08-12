using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NobatOnline.Areas.Makeuper.Models
{
    public class ListTicketModel
    {
        public ListTicketModel()
        {
            List = new List<ListTicketItemModel>();
        }
        public List<ListTicketItemModel> List { get; set; }
    }
    public class ListTicketItemModel
    {
        public int Id { get; set; }
        public string BeautyName { get; set; }
        public DateTime Date { get; set; }
        public string DayName { get; set; }
        public string Time { get; set; }
    }
}
