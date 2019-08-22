using MusicStoreSites.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreSites.Model
{
    public class Genre:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual List<Album> Albums { get; set; }

    }
}
