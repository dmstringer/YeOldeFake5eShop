using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YeOldeFake5eShop.Helpers;
using YeOldeFake5eShop.Models;

namespace YeOldeFake5eShop.ViewModels
{
    public class EquipmentModel
    {
        public List<Equipment> gear = JSONParser.GetEquipment("gear");
        public List<Equipment> armor = JSONParser.GetEquipment("armor");
        public List<Equipment> packs = JSONParser.GetEquipment("packs");
        public List<Equipment> mounts = JSONParser.GetEquipment("mounts");
        public List<Equipment> tools = JSONParser.GetEquipment("tools");
        public List<Equipment> weapons = JSONParser.GetEquipment("weapons");

        /*
        public List<Equipment> findAll() 
        {
            _equipment = new List<Equipment> { }; // he created a dummy list of products

            return _equipment;
        }*/

        public Equipment find(string name)
        {
            List<Equipment> equipment = gear;
            equipment.AddRange(armor);
            equipment.AddRange(packs);
            equipment.AddRange(mounts);
            equipment.AddRange(tools);
            equipment.AddRange(weapons);

            var prod = equipment.Where(a => a.Name == name).FirstOrDefault();
            return prod;
        }
    }
}
