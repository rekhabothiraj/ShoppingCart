using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using MvcApplication1.Interface;

namespace MvcApplication1
{
    public class Checkout : ICheckout
    {
        public IBasket Basket { get; set; }


        public Checkout(IBasket basket)
        {
            Basket = basket;
        }

        public IEnumerable<Item> ItemsSelectedForCheckOut()
        {
           return Basket.SelectedItemsFromTheList();
        }

        public decimal CalculatePriceForcheckOut()
        {
            var selectedItemsFromTheList = Basket.SelectedItemsFromTheList();
            return selectedItemsFromTheList.Aggregate(0, (current, item) => item.SalePrice != 0
                                                                                ? (int) (current + item.SalePrice)
                                                                                : (int) (current + ConvertToNumber(item.PriceOfProduct)));
        }

        private decimal ConvertToNumber(string priceOfProduct)
        {
            var trimEnd = priceOfProduct.TrimEnd('£');
            return int.Parse(trimEnd);

        }
    }
}