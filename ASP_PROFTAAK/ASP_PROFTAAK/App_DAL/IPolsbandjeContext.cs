using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP_PROFTAAK.Models;

namespace ASP_PROFTAAK.App_DAL
{
    public interface IPolsbandjeContext
    {
        List<Polsbandje> getPolsbandjesByReserveringID();


    }
}