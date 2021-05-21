using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YeOldeFake5eShop.Helpers;
using YeOldeFake5eShop.Models;

namespace YeOldeFake5eShop.Controllers
{
    public class CheckoutController : Controller
    {
        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            ViewBag.totalweight = cart.Sum(item => item.Equipment.Weight * item.Quantity);
            ViewBag.totalgold = cart.Sum(item => item.Equipment.Gold * item.Quantity);
            ViewBag.totalsilver = cart.Sum(item => item.Equipment.Silver * item.Quantity);
            ViewBag.totalcopper = cart.Sum(item => item.Equipment.Copper * item.Quantity);
            while (ViewBag.totalcopper > 9)
            {
                ViewBag.totalcopper = ViewBag.totalcopper - 10;
                ViewBag.totalsilver++;
            }
            while (ViewBag.totalsilver > 9)
            {
                ViewBag.totalsilver = ViewBag.totalsilver - 10;
                ViewBag.totalgold++;
            }
            return View();
        }
    }
}
