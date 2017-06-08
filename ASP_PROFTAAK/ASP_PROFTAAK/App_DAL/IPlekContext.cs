using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP_PROFTAAK.Models;

namespace ASP_PROFTAAK.App_DAL
{
    public interface IPlekContext
    {
        List<Plek> GetAll();

        Plek InsertPlek(Plek plek);
        List<Plek> GetPlekByLocatieId(int locatieId);
        bool DeletePlek(int id);

        bool UpdatePlek(Plek plek);
        List<Decimal> GetPlekId(decimal id);
        List<Plek> GetPlekById(List<decimal> id);
        Plek GetPlekById(int id);

        List<Plek> GetPlekByEventId(int eventId);
    }
}