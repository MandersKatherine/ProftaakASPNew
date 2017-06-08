using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASP_PROFTAAK.Models;

namespace ASP_PROFTAAK
{
    public interface ILocatieContext
    {
        List<Locatie> GetAllLocations();

        Locatie GetbyEvent(Event ev);

        Locatie InsertLocatie(Locatie locatie);

        bool DeleteLocatie(int id);

        bool UpdateLocatie(Locatie locatie);
        Locatie GetLocatieById(int id);

        int GetLocatieId();


    }
}
