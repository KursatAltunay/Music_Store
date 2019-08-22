using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStoreSites.UI.MVC.Models
{
    public class CartItemDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public short Amount { get; set; }
        public decimal SubTotal
        {
            get
            {
                return Amount * Price;
            }
        }

    }
}