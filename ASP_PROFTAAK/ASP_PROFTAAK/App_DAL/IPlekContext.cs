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

        bool DeletePlek(int id);

        bool UpdatePlek(Plek plek);

    }
}