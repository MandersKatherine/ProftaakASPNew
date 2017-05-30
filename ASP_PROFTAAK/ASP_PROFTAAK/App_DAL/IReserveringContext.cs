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

        void DeleteReservering(Reservering reserveringen);

    }
}
