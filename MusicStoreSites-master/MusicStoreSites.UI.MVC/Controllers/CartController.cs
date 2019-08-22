using MusicStoreSites.BLL.Abstract;
using MusicStoreSites.UI.MVC.CustomFilter;
using MusicStoreSites.UI.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStoreSites.UI.MVC.Controllers
{
    public class CartController : Controller
    {
        IAlbumService albumService;
        public CartController(IAlbumService AlbumService)
        {
            albumService = AlbumService;
        }
        // GET: Cart

        [CustomFilter]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _CartList()
        {
            return PartialView();
        }


        public ActionResult UpdateCart(short amount,int id)
        {
            MyCart guncellenenSepet = Session["cart"] as MyCart;
            guncellenenSepet.Update(id, amount);
            Session["cart"] = guncellenenSepet;

            return RedirectToAction("_CartList", "Cart");
        }

        public ActionResult DeleteItemCart(int id)
        {
            MyCart silinecekSepet = Session["cart"] as MyCart;
            silinecekSepet.Delete(id);
            Session["cart"] = silinecekSepet;

            return RedirectToAction("_CartList", "Cart");
        }


        public ActionResult _CartButton()
        {
            return PartialView();
        }


        public ActionResult AddToCart(int id)
        {
            if (Session["kullanici"] != null)
            {
                MyCart cart = Session["cart"] as MyCart;

                CartItemDTO cartItem = new CartItemDTO();
                var eklenenAlbum = albumService.Get(id);
                cartItem.ID = eklenenAlbum.ID;
                cartItem.Name = eklenenAlbum.Title;
                cartItem.Price = eklenenAlbum.Discontinued ? eklenenAlbum.Price * 0.9m : eklenenAlbum.Price;
                //indirim varsa indirimli fiyat, yoksa normal fiyatı verir.
                cartItem.Amount = 1;

                cart.Add(cartItem);
                Session["cart"] = cart;
            }
            else
            {
                throw new Exception();
            }

            return PartialView("_CartButton");
        }

    }
}