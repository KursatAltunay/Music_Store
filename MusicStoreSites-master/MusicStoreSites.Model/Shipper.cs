using MusicStoreSites.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreSites.Model
{
    public class Shipper:BaseEntity
    {
        public string CompanyName { get; set; }
        public string Phone { get; set; }


        //Mapping
        public virtual List<Order> Orders { get; set; }

    }
}
