using System;
using System.Collections.Generic;
using System.Linq;
using MvcApplication1.Interface;
using NUnit.Framework;

namespace MvcApplication1.Tests
{
    [TestFixture]
    public class BasketTests
    {
        [Test]
        public void ShouldAddItemsToTheBasket()
        {
            var basket = new Basket();
            var item2 = new Item { NoOfProducts = 2, PriceOfProduct = "3", ProductName = "Milk", ItemCreatedDate = new DateTime(2013, 09, 18), ItemExpiryDate = new DateTime(2013, 09, 21) };

            int count = basket.AddItemsToTheBasket(item2).Count;

            Assert.That(count, Is.EqualTo(1));
        }



        [Test]
        public void ShouldAddTheItemForSale()
        {
            var item1 = new Item { NoOfProducts = 2, PriceOfProduct = "3", ProductName = "Milk", ItemCreatedDate = new DateTime(2013, 09, 18), ItemExpiryDate = new DateTime(2013, 09, 21) };

            var saleItems = new SaleItems();
            IList<Item> saleitems = saleItems.GetTheItemsForSale(item1);

            Assert.That(saleitems.Count,Is.EqualTo(1));
            
        }


        [Test]
        public void ShouldIncrementTheCountOfNoOfProductsWhenSameItemAdded()
        {
            var item2 = new Item { ProductName = "Butter", PriceOfProduct = "3", NoOfProducts = 2, ItemCreatedDate = new DateTime(2013, 09, 18), ItemExpiryDate = new DateTime(2013, 09, 21) };
            var item3 = new Item { ProductName = "Butter", PriceOfProduct = "2", NoOfProducts = 2, ItemCreatedDate = new DateTime(2013, 09, 18), ItemExpiryDate = new DateTime(2013, 09, 21) };

            var basket = new Basket();

            IList<Item> listOfItems = basket.AddItemsToTheBasket(item3);
            Assert.That(listOfItems.Count, Is.EqualTo(1));

            listOfItems = basket.AddItemsToTheBasket(item2);
            Item listItem = listOfItems.FirstOrDefault(l => l.ProductName == item2.ProductName);
            if (listItem != null)
                Assert.That(listItem.NoOfProducts, Is.EqualTo(item3.NoOfProducts));
            Assert.That(listOfItems.Count, Is.EqualTo(1));
        }


        [Test]
        public void ShouldDeleteItemFormTheBasket()
        {
            var item2 = new Item { ProductName = "Butter", PriceOfProduct = "3", NoOfProducts = 2, ItemCreatedDate = new DateTime(2013, 09, 18), ItemExpiryDate = new DateTime(2013, 09, 21) };
            var item3 = new Item { ProductName = "Butter", PriceOfProduct = "2", NoOfProducts = 2, ItemCreatedDate = new DateTime(2013, 09, 18), ItemExpiryDate = new DateTime(2013, 09, 21) };

            var basket = new Basket();

            basket.AddItemsToTheBasket(item3);
            basket.AddItemsToTheBasket(item2);

            basket.DeleteItemFromTheBasket(item2);


            Assert.That(basket.list.Count,Is.EqualTo(1));

        }
    


        [Test]
        public void ShouldRemoveItemsFromTheBasket()
        {
            //use mock
            var item1 = new Item { ProductName = "Butter", PriceOfProduct = "3", NoOfProducts = 2, ItemCreatedDate = new DateTime(2013, 09, 18), ItemExpiryDate = new DateTime(2013, 09, 21) };
            var item2 = new Item { ProductName = "Milk", PriceOfProduct = "2", NoOfProducts = 2, ItemCreatedDate = new DateTime(2013, 09, 18), ItemExpiryDate = new DateTime(2013, 09, 21) };
            var basket = new Basket();

            basket.AddItemsToTheBasket(item1);
            basket.AddItemsToTheBasket(item2);

            IList<Item> itemsFormTheBasket = basket.RemoveItemsFormTheBasket(item1);

            Assert.That(itemsFormTheBasket.Count, Is.EqualTo(1));
        }


        [Test]
        public void ShouldCheckOutTheSelectedItemsFromTheBasket()
        {
            var item1 = new Item { ProductName = "Butter", PriceOfProduct = "3", NoOfProducts = 2, ItemCreatedDate = new DateTime(2013, 09, 18), ItemExpiryDate = new DateTime(2013, 09, 21) };
            var item2 = new Item { ProductName = "Milk", PriceOfProduct = "2", NoOfProducts = 2, ItemCreatedDate = new DateTime(2013, 09, 18), ItemExpiryDate = new DateTime(2013, 09, 21) };
            IBasket basket = new Basket();
            basket.AddItemsToTheBasket(item1);
            basket.AddItemsToTheBasket(item2);

            var checkout = new Checkout(basket);
            IList<Item> itemsForCheckout = checkout.ItemsSelectedForCheckOut().ToList();

            Assert.That(itemsForCheckout.Count, Is.EqualTo(2));
        }



        [Test]
        public void ShouldCalculateThePriceForTheChekedOutItems()
        {
            var item1 = new Item { ProductName = "Butter", PriceOfProduct = "3", NoOfProducts = 2, ItemCreatedDate = new DateTime(2013, 09, 18), ItemExpiryDate = new DateTime(2013, 09, 21) };
            var item2 = new Item { ProductName = "Milk", PriceOfProduct = "2", NoOfProducts = 2, ItemCreatedDate = new DateTime(2013, 09, 18), ItemExpiryDate = new DateTime(2013, 09, 21) };
            int totalPrice = 5;

            IBasket basket = new Basket();
            basket.AddItemsToTheBasket(item1);
            basket.AddItemsToTheBasket(item2);

            var checkout = new Checkout(basket);

            var actual = checkout.CalculatePriceForcheckOut();
            Assert.That(actual,Is.EqualTo(totalPrice));

        }


        [Test]
        public void ShouldAddSalePriceToTheItem()
        {

            var item1 = new Item { ProductName = "Butter", PriceOfProduct = "10", NoOfProducts = 2, ItemCreatedDate = new DateTime(2013, 09, 18), ItemExpiryDate = new DateTime(2013,11,12) };
            var item2 = new Item { ProductName = "Milk", PriceOfProduct = "20", NoOfProducts = 2, ItemCreatedDate = new DateTime(2013, 09, 18), ItemExpiryDate = new DateTime(2013,11,12) };
            var basket = new Basket();

            basket.AddItemsToTheBasket(item1);
            basket.AddItemsToTheBasket(item2);

            Assert.That(item1.SalePrice,Is.EqualTo(5));
            Assert.That(item2.SalePrice,Is.EqualTo(10));

            var checkout = new Checkout(basket);
            var calculatePriceForcheckOut = checkout.CalculatePriceForcheckOut();
            
            Assert.That(calculatePriceForcheckOut,Is.EqualTo(15));
            
        }


    }

    public class SaleItems
    {
        private readonly List<Item> saleList;


        public SaleItems()
        {
            saleList = new List<Item>();
        }

        public IList<Item> GetTheItemsForSale(Item item)
        {
            saleList.Add(item);
            return saleList;
        }
    }
}