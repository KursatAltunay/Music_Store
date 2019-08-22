using MusicStoreSites.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreSites.Model
{
    public class Album :BaseEntity
    {
        public Album()
        {
            Discontinued = false;
        }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public short Stock { get; set; }
        public string AlbumArtUrl { get; set; }
        public bool Discontinued { get; set; }

        public int ArtistID { get; set; }
        public int GenreID { get; set; }


        public virtual Artist Artist { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }

    }
}
