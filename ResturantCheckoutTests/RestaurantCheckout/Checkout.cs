using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantCheckoutTest.RestaurantCheckout
{
    public class Checkout
    {
        //private properties for calculations:
        private const decimal StarterCost = 4.00m;
        private const decimal MainCost = 7.00m;
        private const decimal DrinkCost = 2.50m;
        private const decimal DrinkDiscount = 0.30m;
        private const decimal FoodServiceCharge = 0.10m;

        private List<MenuItem> _orderItems = new List<MenuItem>();

        // add items to list for calculation later
        public void AddToBill(string menucategory, int orderQuantity, DateTime orderTime)
        {
            _orderItems.Add(new MenuItem (menucategory, orderQuantity, orderTime));
        }

        public decimal CalculateBill()
        {
            decimal foodTotal = 0;
            decimal drinkTotal = 0;

            foreach (var item in _orderItems)
            {
                if (item.MenuCategory == "Starter")
                    foodTotal += item.OrderQuantity * StarterCost;
                else if (item.MenuCategory == "Main")
                    foodTotal += item.OrderQuantity * MainCost;
                else if (item.MenuCategory == "Drink")
                {
                    //set the default drink price or apply discount if applicable
                    decimal price = DrinkCost;
                    if (item.OrderTime.Hour < 19)
                        price *= 1 - DrinkDiscount;
                    drinkTotal += item.OrderQuantity * price;
                }
            }

            return Math.Round(foodTotal + foodTotal * FoodServiceCharge + drinkTotal, 2);
        }

        public List<MenuItem> GetOrderItems()
        {
            return _orderItems;
        }

        public void RemoveItem(MenuItem item)
        {
            //if we have multipe items remove an single item else remove from the list entrley
            if(item.OrderQuantity > 1){
                item.OrderQuantity -= 1;
            }
            else
            _orderItems.Remove(item);
        }

    }
}
