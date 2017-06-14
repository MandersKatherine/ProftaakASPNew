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


        public Reservering GetReserveringById(decimal id)
        {
            return context.GetReserveringById(id);
        }

        public void CreateReservering(DateTime datumStart, DateTime datumEinde, int betaald, int accountId,
            int aanwezig, string plekId, string voornaam, string tussenvoegsel, string achternaam, string straat,
            string huisnummer, string woonplaats, string banknummer)
        {
            context.CreateReservering(datumStart, datumEinde, betaald, accountId,
                aanwezig, plekId, voornaam, tussenvoegsel, achternaam, straat,
                huisnummer, woonplaats, banknummer);
        }
        public void DeleteReservering(int id)
        {
            context.DeleteReservering(id);
        }

        public List<Reservering> GetReserveringByAccountId(decimal accountid)
        {
            return context.GetReserveringByAccountId(accountid);
        }


    }
}