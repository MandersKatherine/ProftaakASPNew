using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_PROFTAAK.Models
{
    public class ReserveringViewModelELPRP
    {
        public Event events { get; set; }
        public Locatie locatie { get; set; }
        public List<Plek> plekken { get; set; }
        public Reservering reservering { get; set; }
        public Persoon persoon { get; set; }
        public List<Account> groepsleden { get; set; }
    }
}