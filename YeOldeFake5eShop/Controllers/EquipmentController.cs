using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YeOldeFake5eShop.Models;

namespace YeOldeFake5eShop.Controllers
{
    public class EquipmentController : Controller
    {
        public IActionResult Gear()
        {
            List<Gear> gearList = JSONParser.GetGear();
            return View(gearList);
        }
        public IActionResult Armor()
        {
            return View();
        }
        public IActionResult Packs()
        {
            return View();
        }
        public IActionResult Mounts()
        {
            return View();
        }
        public IActionResult Tools()
        {
            return View();
        }
        public IActionResult Weapons()
        {
            return View();
        }
    }
}
