using MusicStoreSites.DAL.Abstract;
using MusicStoreSites.DAL.Concrete.EntityFramework;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreSites.BLL.Ninject
{
    //Dependency Injection uygulamak için Ninject kütüphanesini kullandık.BLL katmanına Ninject ekledik. UI katmanına Ninject.MVC5 ekledik.
    //Amacımız instance almak yerine enjekte ederek uygulamak.Bunun içinde Ninject module içinde override ettiğimiz load metodunun içindeki Bind metodunu kullandık.
    public class CustomDALModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IAlbumDAL>().To<AlbumRepository>();
            Bind<IArtistDAL>().To<ArtistReposiitory>();
            Bind<IGenreDAL>().To<GenreRepository>();
            Bind<IOrderDAL>().To<OrderRepository>();
            Bind<IUserDAL>().To<UserRepository>();
            Bind<IShipperDAL>().To<ShipperRepository>();
        }
    }
}
