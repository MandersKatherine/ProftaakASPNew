using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP_PROFTAAK.Models
{
    public class Event
    {
        private int id;
        private int locatie_id;

        private string naam;
        private DateTime datumStart;
        private DateTime datumEinde;
        private int maxBezoekers;

        [Required(ErrorMessage = "Required")]
        public int Id { get { return id; } set { id = value; } }
        [Required(ErrorMessage = "Required")]
        public int Locatie_id { get { return locatie_id; } set { locatie_id = value; } }
        [Required(ErrorMessage = "Required")]
        public string Naam { get { return naam; } set { naam = value; } }
        [DisplayName("Start datum")]
        public DateTime DatumStart { get { return datumStart; } set { datumStart = value; } }
        [Required(ErrorMessage = "Required")]
        [DisplayName("Eind datum")]
        public DateTime DatumEinde { get { return datumEinde; } set { datumEinde = value; } }
        [Required(ErrorMessage = "Required")]
        public int MaxBezoekers { get { return maxBezoekers; } set { maxBezoekers = value; } }

        public Event()
        {
            
        }

        public Event(int id, int locatie_id, string naam, DateTime datumStart, DateTime datumEinde, int maxBezoekers)
        {
            this.id = id;
            this.locatie_id = locatie_id;
            this.naam = naam;
            this.datumStart = datumStart;
            this.datumEinde = datumEinde;
            this.maxBezoekers = maxBezoekers;
        }
        public Event(int locatie_id, string naam, DateTime datumStart, DateTime datumEinde, int maxBezoekers)
            :this(-1,locatie_id,naam,datumStart,datumEinde,maxBezoekers)
        {
            
        }
        public override string ToString()
        {
            return naam + " || " + datumStart + " - " + datumEinde + " || " + maxBezoekers;
        }


    }
}