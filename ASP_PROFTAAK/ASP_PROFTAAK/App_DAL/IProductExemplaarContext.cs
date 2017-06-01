using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASP_PROFTAAK.Models;

namespace ASP_PROFTAAK.App_DAL
{
    interface IProductExemplaarContext
    {
        List<ProductExemplaar> GetAllProducts();
        void Insert(ProductExemplaar productExemplaar);
        void Update(ProductExemplaar productExemplaar);
        void Delete(ProductExemplaar productExemplaar);
    }
}
