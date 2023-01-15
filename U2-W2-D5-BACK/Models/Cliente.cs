using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace U2_W2_D5_BACK.Models
{
    public class Cliente
    {
        public int IDCliente { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }

        public string CodiceFiscale { get; set; }

        public string Citta { get; set; }
        public string Email { get; set; }

        public string Telefono { get; set; }



        public static List<SelectListItem> ListaClienti
        {
            get
            {
                List<SelectListItem> selectList = new List<SelectListItem>();
                SqlConnection con = Connessione.GetConnectionDB();
                con.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Clienti", con);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    SelectListItem cliente = new SelectListItem
                    {
                        Text = reader["Cognome"].ToString() + " " + reader["Nome"].ToString(),
                        Value = reader["IdCliente"].ToString()
                    };

                    selectList.Add(cliente);
                }
                return selectList;
            }

        }

        public static List<Cliente> listaClienti = new List<Cliente>();
    }
}