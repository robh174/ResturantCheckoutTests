using System;
using NUnit.Framework;
using Reqnroll;
using ResturantCheckoutTest.RestaurantCheckout;

namespace ResturantCheckoutTest.StepDefinitions
{
    [Binding]
    public class RestaurantCheckoutSystemStepDefinitions
    {
        [Binding]
        public class CheckoutSteps
        {
            private Checkout _checkout;
            private decimal _totalBill;

            public CheckoutSteps()
            {
                _checkout = new Checkout();
            }

            [Given(@"I have added a Starter at (.*) with quantity (.*)")]
            public void GivenIHaveAddedAStarterWithquantity (string time, int quantity)
            {
                _checkout.AddToBill("Starter", quantity, DateTime.Parse(time));
            }


            [Given(@"I have added (.*) Mains at (.*)")]
            public void GivenIHaveAddedMains(int quantity, string time)
            {
                _checkout.AddToBill("Main", quantity, DateTime.Parse(time));
            }

            [Given(@"I have added (.*) Drinks at (.*)")]
            public void GivenIHaveAddedDrinks(int quantity, string time)
            {
                _checkout.AddToBill("Drink", quantity, DateTime.Parse(time));
            }

            [Given(@"I remove (.*) Starter")]
            public void GivenIRemoveStarter(int quantity)
            {
                RemoveItemFromBill("Starter", quantity);
            }

            [Given(@"I remove (.*) Main")]
            public void GivenIRemoveMain(int quantity)
            {
                RemoveItemFromBill("Main", quantity);
            }

            [Given(@"I remove (.*) Drink")]
            public void GivenIRemoveDrink(int quantity)
            {
                RemoveItemFromBill("Drink", quantity);
            }

            [Given(@"I calculate the current the bill")]
            public void WhenICalculateTheCurrentTheBill()
            {
                _totalBill = _checkout.CalculateBill();
            }

            [When(@"I calculate the final bill")]
            public void WhenICalculateTheFinalBill()
            {
                _totalBill = _checkout.CalculateBill();
            }

            [Given(@"the total should be £(.*)")]
            public void ThenTheTotalShouldBe(decimal expectedTotal)
            {
                Assert.AreEqual(expectedTotal, _totalBill);
            }

            [Then(@"the final total should be £(.*)")]
            public void ThenTheFinalTotalShouldBe(decimal expectedTotal)
            {
                Assert.AreEqual(expectedTotal, _totalBill);
            }

            private void RemoveItemFromBill(string category, int quantity)
            {
                for (int i = 0; i < quantity; i++)
                {
                    var itemToRemove = _checkout.GetOrderItems().FindLast(x => x.MenuCategory == category);
                    if (itemToRemove != null)
                    {
                        _checkout.RemoveItem(itemToRemove);
                    }
                }
            }
        }
    }
}
