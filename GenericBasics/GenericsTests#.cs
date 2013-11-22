using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace GenericBasics
{
    [TestFixture]
    public class GenericsTests
    {
        
        [Test]
        public void Should_BeAbleToAdd_Int_ValueToQueue()
        {

            var productList = new ProductList<int>();

            productList.Add(2);

           //Assert.That(productList.GetElements(),Is.EqualTo(2));
            productList.GetNextProduct().Should().Be(2);
        }

        [Test]
        public void ShouldBeAbleToadd_string_ToTheList()
        {
            var productList = new ProductList<string>();

            productList.Add("Hi");

            //Assert.That(productList.GetElements(), Is.EqualTo("Hi"));

            productList.GetNextProduct().Should().Be("Hi");
        }

        [Test]
        public void ShouldBeAbleToContainMultiplItems()
        {
            var productList = new ProductList<string>();

            productList.Add("Hi");
            productList.Add("Bye");

            //Assert.That(productList.GetElements(), Is.EqualTo("Hi"));

            productList.GetNextProduct().Should().Be("Hi");
        }
    }


    public interface IProductList<TProduct>
    {
        void Add(TProduct i);
        TProduct GetNextProduct();
    }

    public class ProductList<TProduct> : IProductList<TProduct>
    {
      
        private Queue<TProduct> queue; 
        
        public ProductList()
        {
           queue = new Queue<TProduct>();
           
        }
        
        public void Add(TProduct i)
        {
            queue.Enqueue(i);
        }

        public TProduct GetNextProduct()
        {
            return queue.Dequeue();
        }

     
    }
}