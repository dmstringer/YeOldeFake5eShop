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
            ViewBag.total = cart.Sum(item => item.Equipment.ConvertedCost * item.Quantity);
            return View();
        }
    }
}
