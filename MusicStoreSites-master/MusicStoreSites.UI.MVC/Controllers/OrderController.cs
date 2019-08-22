using MusicStoreSites.BLL.Abstract;
using MusicStoreSites.UI.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicStoreSites.Model;

namespace MusicStoreSites.UI.MVC.Controllers
{
    public class OrderController : Controller
    {
        IOrderService orderService;
        public OrderController(IOrderService order)
        {
            orderService = order;
        }
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ConfirmCart()
        {
            if (Session["cart"] != null)
            {
                MyCart cart = Session["cart"] as MyCart;
                if (cart.GetAllCartItem.Count > 0)
                {
                    User kullanici = Session["kullanici"] as User;
                    Order order = new Order();

                    order.OrderDate = DateTime.Now;
                    order.ShipAddress = kullanici.Address;
                    order.ShippedDate = DateTime.Now;
                    order.ShipperID = 1;
                    order.Email = kullanici.Email;
                    order.UserDetailID = kullanici.ID;
                    order.OrderDetails = new List<OrderDetail>();

                    foreach (CartItemDTO item in cart.GetAllCartItem)
                    {
                        OrderDetail orderDetail = new OrderDetail();
                        orderDetail.AlbumID = item.ID;
                        orderDetail.Quantity = item.Amount;
                        orderDetail.Cancelled = false;
                        orderDetail.Discount = 0;
                        order.OrderDetails.Add(orderDetail);
                    }
                    orderService.Insert(order);
                    Session["cart"] = new MyCart();
                    return RedirectToAction("Index", "Home");
                }
            }

            return RedirectToAction("Index", "Cart");
        }
    }
}