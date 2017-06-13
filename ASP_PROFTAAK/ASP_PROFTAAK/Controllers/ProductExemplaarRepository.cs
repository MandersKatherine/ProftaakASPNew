using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP_PROFTAAK.App_DAL;
using ASP_PROFTAAK.Models;

namespace ASP_PROFTAAK.Controllers
{
    public class ProductExemplaarRepository
    {
        private IProductExemplaarContext context;
        
        public ProductExemplaarRepository(IProductExemplaarContext context)
        {
            this.context = context;
        }

        public List<ProductExemplaar> GetAllProductExemplaar()
        {
            return context.GetAllProductExemplaar();
        }

        public void Insert(ProductExemplaar productExemplaar, Product product)
        {
            context.Insert(productExemplaar, product);
        }

        public void Update(ProductExemplaar productExemplaar)
        {
            context.Update(productExemplaar);
        }

        public void Delete(ProductExemplaar productExemplaar)
        {
            context.Delete(productExemplaar);
        }
    }
}