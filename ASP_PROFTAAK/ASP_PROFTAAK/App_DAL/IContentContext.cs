using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP_PROFTAAK.Models;

namespace ASP_PROFTAAK.App_DAL
{
    public interface IContentContext
    {
        Bestand getBestandByBijdrageId(int id);
        Bericht getBerichtByBijdrageId(int id);
        Categorie getCategorieByBijdrageId(int id);
        Reactie getReactieByBijdrageId(int id);



    }
}