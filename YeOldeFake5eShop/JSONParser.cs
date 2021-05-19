using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using YeOldeFake5eShop.Models;

namespace YeOldeFake5eShop
{
    public static class JSONParser
    {
        public static Dictionary<string, string[]> categoryDict = new Dictionary<string, string[]> { 
            { "gear", new string[] {"gear_category", "JSONData/AdventuringGear.json"} }, 
            { "armor", new string[] {"armor_category", "JSONData/Armor.json" } }, 
            { "weapons", new string[] {"weapon_category", "JSONData/Weapons.json" } }, 
            { "tools", new string[] {"tool_category", "JSONData/Tools.json" } },
            { "mounts", new string[] {"vehicle_category", "JSONData/MountsAndVehicles.json" } },
            { "packs", new string[] {"gear_category", "JSONData/EquipmentPacks.json" } }
        };

        public static List<Equipment> GetEquipment(string category)
        {
            var path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), categoryDict[category][1]);
            JArray equipmentArray = JArray.Parse(File.ReadAllText(path));
            List<Equipment> equipmentObjList = new List<Equipment>() { };

            foreach (JObject item in equipmentArray)
            {
                Equipment gearItem = new Equipment() { };

                gearItem.Name = (string)item["name"];
                gearItem.CostQuantity = (int)item["cost"]["quantity"];
                gearItem.CostUnit = (string)item["cost"]["unit"];
                gearItem.Weight = (double)item["weight"];
                gearItem.DisplayOrder = (int)item["display_order"];
                gearItem.Description = (string)item["desc"];

                if (category == "gear" || category == "packs") {
                    gearItem.GearCategory = (string)item[categoryDict[category][0]]["name"];
                } else {
                    gearItem.GearCategory = (string)item[categoryDict[category][0]];
                }
                equipmentObjList.Add(gearItem);
            }
            var sortedObjList = equipmentObjList.OrderBy(gear => gear.DisplayOrder).ToList();
            return sortedObjList;
        }
    }
}
