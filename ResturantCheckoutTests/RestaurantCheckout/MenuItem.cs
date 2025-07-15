using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantCheckoutTest.RestaurantCheckout
{
    public class MenuItem
    {
        public MenuItem(string menuCategory, int orderQuantity, DateTime orderTime)
        {
            MenuCategory = menuCategory;
            OrderQuantity = orderQuantity;
            OrderTime = orderTime;
        }

        public string MenuCategory { get; set; }
        public int OrderQuantity { get; set; }
        public DateTime OrderTime { get; set; }
    }
}
