using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP_PROFTAAK.Models;

namespace ASP_PROFTAAK.App_DAL
{
    public interface IProductContext
    {
        List<Product> GetAllProducts();
        void Insert(Product product, ProductCategorie productCategorie);
        void Update(Product product, ProductCategorie productCategorie);
        void Delete(Product product);
        Product GetProduct(int id);
        void Update(Product product);
        bool ReturnProduct(int id);
        bool Betaal(int id);


    }
}