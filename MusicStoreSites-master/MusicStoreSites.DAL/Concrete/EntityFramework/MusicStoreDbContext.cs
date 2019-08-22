using MusicStoreSites.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreSites.DAL.Concrete.EntityFramework
{
    public class MusicStoreDbContext:DbContext
    {
        public MusicStoreDbContext():base("server=.;database=MusicStoreSitesDB;integrated security=true;")
        {
            Database.SetInitializer<MusicStoreDbContext>(new MyStrategy());
            //dbContext ayağa kalkarken bir strateji kullanmak istedik, bu strateji ile birlikte dbContext oluştuğunda yani veritabanı sql tarafında oluştuğunda içinde hazır veriler de olsun, bunun için DropCreateDatabaseIfModelChanges yaklaşımını kullandık.
        }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<User> UserDetails { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties().Where(a => a.PropertyType == typeof(DateTime)).Configure(a => a.HasColumnType("datetime2"));

            modelBuilder.Configurations.Add(new OrderDetailMapping());

            //modellerimin içindeki propertylerden tip olarak datetime kullanan varsa, sql tarafında karşılığını bulamaz diye tipini çevirme işlemi yapıyoruz.modelle ilgili değişiklik yaptığımız içinde bunu OnModelCreating metodunu override ederek yazıyoruz.
        }




    }
}
