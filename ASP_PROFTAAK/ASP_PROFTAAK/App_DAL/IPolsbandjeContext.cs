using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP_PROFTAAK.Models;

namespace ASP_PROFTAAK.App_DAL
{
    public interface IPolsbandjeContext
    {
        List<Polsbandje> getPolsbandjesByReserveringID(int reserveringid);

        Polsbandje InsertPolsbandje(Polsbandje polsbandje);

        bool DeletePolsbandje(int id);

        bool UpdatePolsbandje(Polsbandje polsbandje);

        List<Polsbandje> GetAllPolsbandjes();

        Polsbandje GetPolsbandjeById(decimal id);

        Polsbandje GetEventByPolsbandjeId(int id);
    }
}