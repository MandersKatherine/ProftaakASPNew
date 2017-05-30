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