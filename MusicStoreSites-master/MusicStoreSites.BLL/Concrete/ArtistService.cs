using MusicStoreSites.BLL.Abstract;
using MusicStoreSites.DAL.Abstract;
using MusicStoreSites.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreSites.BLL.Concrete
{
    public class ArtistService : IArtistService
    {
        IArtistDAL _artistDAL;

        public ArtistService(IArtistDAL artistDAL)
        {
            _artistDAL = artistDAL;
        }

        public void Delete(Artist entity)
        {
            _artistDAL.Remove(entity);
        }

        public void DeleteByID(int entityID)
        {
            Delete(Get(entityID));
        }

        public Artist Get(int entityID)
        {
            return _artistDAL.Get(a => a.ID == entityID);
        }

        public ICollection<Artist> GetAll()
        {
            return _artistDAL.GetAll();
        }

        public void Insert(Artist entity)
        {
            _artistDAL.Add(entity);
        }

        public void Update(Artist entity)
        {
            _artistDAL.Update(entity);
        }
    }
}
