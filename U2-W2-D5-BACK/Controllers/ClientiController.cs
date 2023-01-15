using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using U2_W2_D5_BACK.Models;

namespace U2_W2_D5_BACK.Controllers
{
    public class ClientiController : Controller
    {
        // GET: Clienti
        public ActionResult ListaClienti()
        {
            Cliente.listaClienti.Clear();
            SqlConnection con = Connessione.GetConnectionDB();
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Clienti", con);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Cliente clienti = new Cliente();
                    clienti.IDCliente = Convert.ToInt32(reader["IDCliente"]);
                    clienti.Nome = reader["Nome"].ToString();
                    clienti.Cognome = reader["Cognome"].ToString();
                    clienti.CodiceFiscale = reader["CodiceFiscale"].ToString();
                    clienti.Telefono = reader["Telefono"].ToString() ;
                    clienti.Email = reader["Email"].ToString();                  
                    clienti.Citta = reader["Citta"].ToString();
                    

                    Cliente.listaClienti.Add(clienti);
                }
            }catch(Exception ex)
            {
               
            }
            con.Close();


            
            return View(Cliente.listaClienti);
        }
    }
}