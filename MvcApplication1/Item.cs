using System;

namespace MvcApplication1
{
    public class Item
    {

        private string _priceOfProduct;

       
        public int NoOfProducts { get; set; }

        public string PriceOfProduct
        {
            get { return _priceOfProduct; }
            set { _priceOfProduct = value + "£"; }
        }

        public string ProductName { get; set; }
        public DateTime ItemCreatedDate { get; set; }
        public DateTime ItemExpiryDate { get; set; }

        public decimal SalePrice
        {
            get; set;
        }

        public void AddSalePRiceToTheItem()
        {
            throw new NotImplementedException();
        }
    }
}