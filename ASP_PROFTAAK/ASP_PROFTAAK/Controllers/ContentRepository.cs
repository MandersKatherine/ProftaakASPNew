using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP_PROFTAAK.App_DAL;
using ASP_PROFTAAK.Models;

namespace ASP_PROFTAAK.Controllers
{
    public class ContentRepository
    {
        private readonly IContentContext context;

        public ContentRepository(IContentContext context)
        {
            this.context = context;
        }

        public Bestand getBestandByBijdrageId(int id)
        {
            return context.getBestandByBijdrageId(id);
        }

        public Bericht getBerichtByBijdrageId(int id)
        {
            return context.getBerichtByBijdrageId(id);
        }

        public Categorie getCategorieByBijdrageId(int id)
        {
            return context.getCategorieByBijdrageId(id);
        }
    }
}