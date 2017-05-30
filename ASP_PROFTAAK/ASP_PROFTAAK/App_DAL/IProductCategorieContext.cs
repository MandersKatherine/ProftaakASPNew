using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP_PROFTAAK.Models;

namespace ASP_PROFTAAK.App_DAL
{
    public interface IProductCategorieContext
    {
        List<ProductCategorie>GetAllCategories();
        void Insert(ProductCategorie productCategorie);
        void Update(ProductCategorie productCategorie);
        void Delete(ProductCategorie productCategorie);
    }
}