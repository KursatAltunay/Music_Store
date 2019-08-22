using MusicStoreSites.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreSites.Core.DAL
{
    public interface IRepository<TEntity>
        where TEntity:BaseEntity
        //bu interface'i implement edecek class Entity tipinde olmak zorunda
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);

        TEntity Get(Expression<Func<TEntity, bool>> filter);
        //get metodu için içine lambda sorgusu yazılabilecek bir parametre oluşturmuş olduk

        ICollection<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);
        

        /* Create
         * Read (get-getall)
         * Update
         * Delete
         */
    }
}
