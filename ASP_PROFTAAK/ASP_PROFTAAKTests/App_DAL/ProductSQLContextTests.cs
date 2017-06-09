using Microsoft.VisualStudio.TestTools.UnitTesting;
using ASP_PROFTAAK.App_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASP_PROFTAAK.Controllers;
using ASP_PROFTAAK.Models;

namespace ASP_PROFTAAK.App_DAL.Tests
{
    [TestClass()]
    public class ProductSQLContextTests
    {
        ProductRepository repository = new ProductRepository(new ProductSQLContextTest()); 

        [TestMethod()]
        public void GetAllProductsTest()
        {
            List<Product> productlist = repository.GetAllProducts();
            Product[] productenlijst = productlist.ToArray();
            Assert.AreEqual("Zeddro", productenlijst[0].Serie);
        }

        [TestMethod]
        public void InsertTest()
        {
            Product product = new Product(4, 4, "Coca Cola", "Zeddro", "10", 10);
            ProductCategorie productCategory = new ProductCategorie(1, 1, "frisdrank");
            repository.Insert(product, productCategory);
            Assert.IsNotNull(repository.GetAllProducts().Where(x => x.ProductId == product.ProductId));
            
           
        }

        //[TestMethod()]
        //public void UpdateTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void DeleteTest()
        //{
        //    Assert.Fail();
        //}

        private class ProductSQLContextTest : IProductContext
        {
            private List<Product> producten;

            public ProductSQLContextTest()
            {
                producten = new List<Product>()
                {
                    new Product(1, 1, "Coca Cola", "Zeddro", "10", 10),
                    new Product(2, 1, "Coca", "zdddz", "11", 11),
                    new Product(3, 1, "Coca Hall", "zz", "12", 12)
                };
            }

            public List<Product> GetAllProducts()
            {
                return producten;
            }

            public void Insert(Product product, ProductCategorie productCategorie)
            {
                
            }

            public void Update(Product product, ProductCategorie productCategorie)
            {
                throw new NotImplementedException();
            }

            public void Delete(Product product)
            {
                throw new NotImplementedException();
            }
        }
    }
}