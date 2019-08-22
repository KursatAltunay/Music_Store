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
    public class GenreService : IGenreService
    {
        IGenreDAL _genreDAL;
        public GenreService(IGenreDAL genreDAL)
        {
            _genreDAL = genreDAL;
        }

        public void Delete(Genre entity)
        {
            _genreDAL.Remove(entity);
        }

        public void DeleteByID(int entityID)
        {
            Delete(Get(entityID));
        }

        public Genre Get(int entityID)
        {
            return _genreDAL.Get(a => a.ID == entityID);
        }

        public ICollection<Genre> GetAll()
        {
            return _genreDAL.GetAll();
        }

        public void Insert(Genre entity)
        {
            _genreDAL.Add(entity);
        }

        public void Update(Genre entity)
        {
            _genreDAL.Update(entity);
        }
    }
}
