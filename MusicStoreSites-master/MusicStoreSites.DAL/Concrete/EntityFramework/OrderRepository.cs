using MusicStoreSites.Core.DAL.EntityFramework;
using MusicStoreSites.DAL.Abstract;
using MusicStoreSites.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreSites.DAL.Concrete.EntityFramework
{
   public class OrderRepository:EFRepositoryBase<Order,MusicStoreDbContext>,IOrderDAL
    {
    }
}
