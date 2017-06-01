using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP_PROFTAAK.App_DAL;
using ASP_PROFTAAK.Models;

namespace ASP_PROFTAAK.Controllers
{
    public class ReserveringRepository
    {
        private IReserveringContext context;

        public ReserveringRepository(IReserveringContext context)
        {
            this.context = context;
        }

        public List<Reservering> GetAllReserveringen()
        {
            return context.GetAllReserveringen();
        }

        public Reservering InsertReservering(Reservering reserveringen)
        {
            return context.InsertReservering(reserveringen);
        }

        public void UpdateReservering(Reservering reserveringen)
        {
            context.UpdateReservering(reserveringen);
        }

        public void DeleteReservering(Reservering reserveringen)
        {
            context.DeleteReservering(reserveringen);
        }
        public Reservering GetReserveringById(decimal id)
        {
            return context.GetReserveringById(id);
        }
    }
}