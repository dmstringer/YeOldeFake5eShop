using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YeOldeFake5eShop.Models
{
    public class Item
    {
        //this class is to track a piece of Equipment and its quantity for the cart
        public Equipment Equipment { get; set; }
        public int Quantity { get; set; }
    }
}
