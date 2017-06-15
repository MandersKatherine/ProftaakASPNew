using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP_PROFTAAK.App_DAL;
using ASP_PROFTAAK.Models;

namespace ASP_PROFTAAK.Controllers
{
    public class ProductRepository
    {
        private IProductContext context;

        public ProductRepository(IProductContext context)
        {
            this.context = context;
        }

        public Product GetProduct(int id)
        {
            return context.GetProduct(id); 
        }

        public bool Betaal(int id)
        {
            return context.Betaal(id);
        }

        public bool ReturnProduct(int id)
        {
            return context.ReturnProduct(id);
        }
        public void Update(Product product)
        {
            context.Update(product); 
        }

        public List<Product> GetAllProducts()
        {
            return context.GetAllProducts();
        }

        public void Insert(Product product, ProductCategorie productCategorie)
        {
            context.Insert(product, productCategorie);
        }

        public void Update(Product product, ProductCategorie productCategorie)
        {
            context.Update(product, productCategorie);
        }

        public void Delete(Product product)
        {
            context.Delete(product);
        }
    }
}