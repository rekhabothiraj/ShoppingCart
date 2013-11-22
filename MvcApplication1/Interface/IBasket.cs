using System.Collections.Generic;

namespace MvcApplication1.Interface
{
    public interface IBasket
    {
        IList<Item> AddItemsToTheBasket(Item item);
        IList<Item> RemoveItemsFormTheBasket(Item item);
        IEnumerable<Item> SelectedItemsFromTheList();
        void DeleteItemFromTheBasket(Item item);
    }
}