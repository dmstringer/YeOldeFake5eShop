using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YeOldeFake5eShop.Helpers;
using YeOldeFake5eShop.Models;
using YeOldeFake5eShop.ViewModels;

namespace YeOldeFake5eShop.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            if (SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart") == null) 
            {
                return RedirectToAction("NoCart");
            }
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

        public IActionResult NoCart()
        {
            
            return View();
        }

        private int isExist(string id)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++) {
                if (cart[i].Equipment.Name.Equals(id)) {
                    return i;
                }
            }
            return -1;
        }

        public IActionResult Buy(string id)
        {
            EquipmentModel equipmentModel = new EquipmentModel();

            if(SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart") == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item { Equipment = equipmentModel.find(id), Quantity = 1 });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            } else
            {
                List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }else
                {
                    cart.Add(new Item { Equipment = equipmentModel.find(id), Quantity = 1 });
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Remove(string id)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            int index = isExist(id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }

        public IActionResult Up(string id)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            int index = isExist(id);
            cart[index].Quantity++;
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }

        public IActionResult Down(string id)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            int index = isExist(id);
            if (cart[index].Quantity > 1)
            {
                cart[index].Quantity--;
            }
            else
            {
                return RedirectToAction("Remove", new { id = id });
            }
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }
    }
}
