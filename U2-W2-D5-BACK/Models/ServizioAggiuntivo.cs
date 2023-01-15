using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace U2_W2_D5_BACK.Models
{
    public class ServizioAggiuntivo
    {
        public int Id { get; set; }
        public string DescrizioneServizio { get; set; }
        public decimal CostoServizio { get; set; }
        public DateTime DataServizio { get; set; }
        public int IDPrenotazione { get; set; }
        public Prenotazione Prenotazione { get; set; }

        public static List<ServizioAggiuntivo> listaServizi = new List<ServizioAggiuntivo>();
    }
}