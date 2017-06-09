using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASP_PROFTAAK.Models;

namespace ASP_PROFTAAK.App_DAL
{
    public interface ISpecificatieContext
    {
        List<Specificatie> GetAll();
        void InsertSpecificatie(Specificatie specificatie);

        bool DeleteSpecificatie(int id);

        bool UpdateSpecificatie(Specificatie specificatie);
    }
}
