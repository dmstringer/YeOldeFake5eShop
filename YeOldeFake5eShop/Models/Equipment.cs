using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YeOldeFake5eShop.Models
{
    public class Equipment
    {
        public string Name { get; set; }
        public string GearCategory { get; set; }
        public int CostQuantity { get; set; }
        public string CostUnit { get; set; }
        public double Weight { get; set; }
        public int DisplayOrder { get; set; }
        public string Description { get; set; }
    }
}
