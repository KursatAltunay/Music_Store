using MusicStoreSites.BLL.Abstract;
using MusicStoreSites.Model;
using MusicStoreSites.UI.MVC.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStoreSites.UI.MVC.Controllers
{
    public class AccountController : Controller
    {
       

        IUserService userService;
        public AccountController(IUserService UserService)
        {
            userService = UserService;
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            try
            {
                userService.Insert(user);
                bool sonuc = MailHelper.SendConfirmationMail(user.UserName, user.Password, user.Email, user.ID);
                if (!sonuc)
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Veritabanı ekleme hatası!";
                return View();
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            var gelenKullanici = userService.GetUserByLogin(user.UserName, user.Password);
            if (gelenKullanici != null)
            {
                Session["kullanici"] = gelenKullanici;
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Error = "Kullanıcı bulunamadı";
            return View();
        }


        public ActionResult Index()
        {
            return View();
        }
    }
}