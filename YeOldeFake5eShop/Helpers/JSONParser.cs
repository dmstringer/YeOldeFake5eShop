using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using YeOldeFake5eShop.Models;

namespace YeOldeFake5eShop.Helpers
{
    public static class JSONParser
    {
        //EquipmentController will pass in a category type to the GetEquipment method.
        //This dictionary is them used for two things:
        //1. dictates the file path to the JSON file I want to open for the specific equipment data
        //2. during the formation of the Equipment items, it will use whatever 'sub' category name I need for that specific category type
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
                gearItem.Gold = 0;
                gearItem.Silver = 0;
                gearItem.Copper = 0;

                if (category == "gear" || category == "packs") {
                    gearItem.GearCategory = (string)item[categoryDict[category][0]]["name"];
                } else {
                    gearItem.GearCategory = (string)item[categoryDict[category][0]];
                }

                if ((string)item["cost"]["unit"] == "gp") {
                    gearItem.Gold = (int)item["cost"]["quantity"];
                } else if ((string)item["cost"]["unit"] == "sp") {
                    gearItem.Silver = (int)item["cost"]["quantity"];
                } else {
                    gearItem.Copper = (int)item["cost"]["quantity"];
                }

                equipmentObjList.Add(gearItem);
            }
            var sortedObjList = equipmentObjList.OrderBy(gear => gear.DisplayOrder).ToList();
            return sortedObjList;
        }
    }
}
