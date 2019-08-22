using MusicStoreSites.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreSites.Model
{
    public class Order:BaseEntity
    {
        public int UserDetailID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int ShipperID { get; set; }
        public string ShipAddress { get; set; }

        //Mapping
        public virtual User UserDetail { get; set; }
        public virtual Shipper Shipper { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }







    }
}
