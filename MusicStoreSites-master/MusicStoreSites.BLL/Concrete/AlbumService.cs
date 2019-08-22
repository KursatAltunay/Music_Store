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
    public class AlbumService : IAlbumService
    {
        IAlbumDAL _albumDAL;

        public AlbumService(IAlbumDAL albumDAL)
        {
            _albumDAL = albumDAL;
        }

        public void Delete(Album entity)
        {
            _albumDAL.Remove(entity);
        }

        public void DeleteByID(int entityID)
        {
            Delete(Get(entityID));
        }

        public Album Get(int entityID)
        {
            return _albumDAL.Get(a => a.ID == entityID);
        }

        public List<Album> GetAlbumsOfGenre(int genreID)
        {
            return _albumDAL.GetAll(a => a.GenreID == genreID).ToList();
        }

        public ICollection<Album> GetAll()
        {
            return _albumDAL.GetAll();
        }

        public List<Album> GetDiscontinuedAlbums()
        {
            return _albumDAL.GetAll(a => a.Discontinued).ToList();
        }

        public List<Album> GetLastFiveAlbums()
        {
            return _albumDAL.GetAll().OrderByDescending(a => a.CreatedDate).Take(5).ToList();
        }

        public void Insert(Album entity)
        {
            _albumDAL.Add(entity);
        }

        public void Update(Album entity)
        {
            _albumDAL.Update(entity);
        }
    }
}
