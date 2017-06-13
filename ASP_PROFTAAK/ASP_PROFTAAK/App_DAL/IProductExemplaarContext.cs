using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASP_PROFTAAK.Models;

namespace ASP_PROFTAAK.App_DAL
{
    public interface IProductExemplaarContext
    {
        List<ProductExemplaar> GetAllProductExemplaar();
        void Insert(ProductExemplaar productExemplaar, Product product);
        void Update(ProductExemplaar productExemplaar);
        void Delete(ProductExemplaar productExemplaar);
        List<ProductExemplaar> GetAllBeschikbareProductExemplaren();
        ProductExemplaar GetByProductExemplaarID(int id);


    }
}
