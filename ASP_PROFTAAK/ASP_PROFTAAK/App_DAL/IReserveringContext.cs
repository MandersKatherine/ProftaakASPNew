using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASP_PROFTAAK.Models;

namespace ASP_PROFTAAK.App_DAL
{
    public interface IReserveringContext
    {
        List<Reservering> GetAllReserveringen();

        Reservering InsertReservering(Reservering reserveringen);

        void UpdateReservering(Reservering reserveringen);


        Reservering GetReserveringById(decimal id);

        List<Reservering> GetReserveringByAccountId(decimal accountid);


        void CreateReservering(DateTime datumStart, DateTime datumEinde, int betaald, int accountId, int aanwezig,
            string plekId, string voornaam, string tussenvoegsel, string achternaam, string straat, string huisnummer,
            string woonplaats, string banknummer);

        void DeleteReservering(int id);
    }
}
