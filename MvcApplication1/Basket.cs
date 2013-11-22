using System.Collections.Generic;
using System.Linq;
using MvcApplication1.Interface;

namespace MvcApplication1
{
    public class Basket : IBasket
    {
        public IList<Item> list;

        public Basket()
        {
            list = new List<Item>();
        }

        public IList<Item> AddItemsToTheBasket(Item items)
        {
            if (items != null)
            {
                Item listItem = list.FirstOrDefault(l => l.ProductName == items.ProductName);
                double totalDays = (items.ItemCreatedDate - items.ItemExpiryDate).TotalDays;
                items.SalePrice = totalDays <= 5 ? GetSalePrice(items) : items.SalePrice = 0;
                if (listItem == null)
                {
                    list.Add(items);
                }
                else
                {
                    IncrementTheProduct(listItem, items);
                }
            }
            return list;
        }

        private static void IncrementTheProduct(Item listItem, Item item)
        {
            listItem.NoOfProducts = item.NoOfProducts + listItem.NoOfProducts;
        }

        private static int GetSalePrice(Item items)
        {
            int price = int.Parse(items.PriceOfProduct.TrimEnd('£'));
            return (price*5)/10;
        }

        public IList<Item> RemoveItemsFormTheBasket(Item item)
        {
            if (list.FirstOrDefault(l => l.ProductName == item.ProductName) != null)
                list.Remove(item);
            return list;
        }

        public IEnumerable<Item> SelectedItemsFromTheList()
        {
            return list;
        }

        public void DeleteItemFromTheBasket(Item item)
        {
            if (item != null) list.Remove(item);
        }
    }
}