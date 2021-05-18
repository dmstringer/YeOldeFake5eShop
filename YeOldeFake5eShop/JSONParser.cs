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
        public static List<Gear> GetGear()
        {
            var path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "JSONData/AdventuringGear.json");
            JArray gearArray = JArray.Parse(File.ReadAllText(path));
            List<Gear> gearObjList = new List<Gear>() { };

            foreach (JObject item in gearArray)
            {
                Gear gearItem = new Gear() { 
                    Name = (string)item["name"],
                    GearCategory = (string)item["gear_category"]["name"],
                    CostQuantity = (int)item["cost"]["quantity"],
                    CostUnit = (string)item["cost"]["unit"],
                    Weight = (int)item["weight"],
                    DisplayOrder = (int)item["display_order"],
                    Description = (string)item["desc"]
                };
                gearObjList.Add(gearItem);
            }
            return gearObjList;
        }
        /*
        public static JArray GetArmor()
        {

        }
        public static JArray GetTools()
        {

        }
        public static JArray GetWeapons()
        {

        }
        public static JArray GetMounts()
        {

        }
        public static JArray GetPacks()
        {

        }
        */
    }
}
