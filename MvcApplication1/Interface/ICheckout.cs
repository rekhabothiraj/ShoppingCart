using System.Collections.Generic;

namespace MvcApplication1.Interface
{
    public interface ICheckout
    {
        IEnumerable<Item> ItemsSelectedForCheckOut();
    }
}