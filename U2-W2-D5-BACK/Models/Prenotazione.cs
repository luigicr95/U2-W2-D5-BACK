using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace U2_W2_D5_BACK.Models
{
    public class Prenotazione
    {
        public int ID { get; set; }
        public int IDCliente { get; set; }
        public Cliente Cliente { get; set;}
        public int IDCamera { get; set; }
        public Camera Camera { get; set; }
        public int IDSoggiorno { get; set; }
        public Soggiorno Soggiorno { get; set; }
        public DateTime DataPrenotazione { get; set; }
        public DateTime DataInizio { get; set; }
        public DateTime DataFine { get; set; }
        public decimal Caparra { get; set; }
        public decimal Totale { get; set; }

        public static List<Prenotazione> listaPrenotazioni = new List<Prenotazione>();
    }
}