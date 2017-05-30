using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASP_PROFTAAK.Models;

namespace ASP_PROFTAAK.App_DAL
{
    public interface IPersoonContext
    {
        List<Persoon> GetAllPersonen();

        Persoon InsertPersoon(Persoon persoon);

        bool UpdatePersoon(Persoon persoon);

        bool DeletePersoon(int id);
        Persoon getHoofdboekerByReserveringId(int id);

    }
}
