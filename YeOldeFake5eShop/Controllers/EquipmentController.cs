using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YeOldeFake5eShop.Models;
using YeOldeFake5eShop.Helpers;

namespace YeOldeFake5eShop.Controllers
{
    public class EquipmentController : Controller
    {
        public IActionResult Gear()
        {
            List<Equipment> gearList = JSONParser.GetEquipment("gear");
            return View(gearList);
        }
        public IActionResult Armor()
        {
            List<Equipment> armorList = JSONParser.GetEquipment("armor");
            return View(armorList);
        }
        public IActionResult Packs()
        {
            List<Equipment> packsList = JSONParser.GetEquipment("packs");
            return View(packsList);
        }
        public IActionResult Mounts()
        {
            List<Equipment> mountsList = JSONParser.GetEquipment("mounts");
            return View(mountsList);
        }
        public IActionResult Tools()
        {
            List<Equipment> toolsList = JSONParser.GetEquipment("tools");
            return View(toolsList);
        }
        public IActionResult Weapons()
        {
            List<Equipment> weaponsList = JSONParser.GetEquipment("weapons");
            return View(weaponsList);
        }
    }
}
