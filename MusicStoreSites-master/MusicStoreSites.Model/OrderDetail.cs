using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreSites.Model
{
    public class OrderDetail
    {
        public OrderDetail()
        {
            Cancelled = false;
            Discount = 0;
        }
        public int OrderID { get; set; }
        public int AlbumID { get; set; }
        public short Quantity { get; set; }
        public double Discount { get; set; }

        public bool Cancelled { get; set; }
        //sipariş iptal olsa da hangi ürünleri içerdiği bilgisi önemli olduğundan bu seçenek eklendi
        public string Notes { get; set; }
        //iptal edilen siparişin iptal nedenleri için

        //Mapping
        public virtual Order Order { get; set; }
        public virtual Album Album { get; set; }





    }
}
