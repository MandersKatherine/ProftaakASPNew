using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP_PROFTAAK.App_DAL;
using ASP_PROFTAAK.Models;

namespace ASP_PROFTAAK.Controllers
{
    public class GroepslidRepository
    {
        private readonly IGroepslidContext context;

        public GroepslidRepository(IGroepslidContext context)
        {
            this.context = context;
        }

        public void GeefGroepslidBandjeEnKoppelAanLaatstGeinserteReservering(int accountId)
        {
            context.GeefGroepslidBandjeEnKoppelAanLaatstGeinserteReservering(accountId);
        }

        public List<Groepslid> getGroepsledenByReserveringId(int id)
        {
            return context.getGroepsledenByReserveringId(id);
        }


    }
}