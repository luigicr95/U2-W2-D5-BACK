using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace U2_W2_D5_BACK.Models
{
    public class ContoTotale
    {
        public decimal TotaleServizi { get; set; }
        public decimal CaparraVersata { get; set; }
        public decimal TotalePrenotazione { get; set; }
        public decimal TotaleEffettivo { get; set; }

        public static List<ContoTotale> listaConto = new List<ContoTotale>();
    }
}