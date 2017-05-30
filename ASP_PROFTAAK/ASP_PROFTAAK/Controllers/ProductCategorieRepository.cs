using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP_PROFTAAK.App_DAL;
using ASP_PROFTAAK.Models;

namespace ASP_PROFTAAK.Controllers
{
    public class ProductCategorieRepository
    {
        private IProductCategorieContext context;

        public ProductCategorieRepository(IProductCategorieContext context)
        {
            this.context = context;
        }

        public List<ProductCategorie> GetAllCategories()
        {
            return context.GetAllCategories();
        }

        public void Insert(ProductCategorie productCategorie)
        {
            context.Insert(productCategorie);
        }

        public void Update(ProductCategorie productCategorie)
        {
            context.Update(productCategorie);
        }

        public void Delete(ProductCategorie productCategorie)
        {
            context.Delete(productCategorie);
        }
    }
}