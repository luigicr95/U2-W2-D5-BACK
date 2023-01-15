using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using U2_W2_D5_BACK.Models;

namespace U2_W2_D5_BACK.Controllers
{
    [Authorize]
    public class PrenotazioniController : Controller
    {
        // GET: Prenotazioni
        public ActionResult ListaPrenotazioni()
        {
            Prenotazione.listaPrenotazioni.Clear();
            SqlConnection con = Connessione.GetConnectionDB();
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Prenotazioni INNER JOIN Clienti ON Prenotazioni.IDCliente = Clienti.IDCliente INNER JOIN Camere ON Prenotazioni.IDCamera = Camere.IDCamera INNER JOIN Soggiorni ON Prenotazioni.IDSoggiorno = Soggiorni.IDSoggiorno", con);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Prenotazione prenotazione = new Prenotazione();
                    Cliente clienti = new Cliente();
                    clienti.IDCliente = Convert.ToInt32(reader["IDCliente"]);
                    clienti.Nome = reader["Nome"].ToString();
                    clienti.Cognome = reader["Cognome"].ToString();
                    clienti.CodiceFiscale = reader["CodiceFiscale"].ToString();
                    Camera camera = new Camera();
                    camera.Id = Convert.ToInt32(reader["IDCamera"]);
                    camera.NumeroCamera = Convert.ToInt32(reader["NumeroCamera"]);
                    Soggiorno soggiorno = new Soggiorno();
                    soggiorno.IDSoggiorno = Convert.ToInt32(reader["IDSoggiorno"]);
                    soggiorno.TipoSoggiorno = reader["TipoSoggiorno"].ToString();
                    prenotazione.ID = Convert.ToInt32(reader["IDPrenotazione"]);
                    prenotazione.DataPrenotazione = Convert.ToDateTime(reader["DataPrenotazione"]);
                    prenotazione.DataInizio = Convert.ToDateTime(reader["Datainizio"]);
                    prenotazione.DataFine = Convert.ToDateTime(reader["DataFine"]);
                    prenotazione.Caparra = Convert.ToDecimal(reader["Caparra"]);
                    prenotazione.Totale = Convert.ToDecimal(reader["Totale"]);
                    prenotazione.Cliente = clienti;
                    prenotazione.Camera = camera;
                    prenotazione.Soggiorno = soggiorno;


                    Prenotazione.listaPrenotazioni.Add(prenotazione);
                }
            }
            catch (Exception ex)
            {

            }
            con.Close();



            return View(Prenotazione.listaPrenotazioni);
        }

        public ActionResult AggiungiPrenotazioni()
        {
            ViewBag.ListaClienti = Cliente.ListaClienti;
            ViewBag.ListaSoggiorni = Soggiorno.ListaSoggiorni;
            ViewBag.ListaCamere = Camera.ListaCamere;
            
            return View();
        }

        [HttpPost]
        public ActionResult AggiungiPrenotazioni(Prenotazione prenotazione)
        {
            SqlConnection con = Connessione.GetConnectionDB();
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand("INSERT INTO Prenotazioni VALUES (@IDCliente, @IDCamera, @DataPrenotazione, @DataInizio, @DataFine, @Caparra, @Totale, @IDSoggiorno)", con);
                command.Parameters.AddWithValue("@IDCliente", prenotazione.IDCliente);
                command.Parameters.AddWithValue("@IDCamera", prenotazione.IDCamera);
                command.Parameters.AddWithValue("@DataPrenotazione", prenotazione.DataPrenotazione);
                command.Parameters.AddWithValue("@DataInizio", prenotazione.DataInizio);
                command.Parameters.AddWithValue("@DataFine", prenotazione.DataFine);
                command.Parameters.AddWithValue("@Caparra", prenotazione.Caparra);
                command.Parameters.AddWithValue("@Totale", prenotazione.Totale);
                command.Parameters.AddWithValue("@IDSoggiorno", prenotazione.IDSoggiorno);

                command.ExecuteNonQuery();

                
            }catch(Exception ex)
            {

            }
            con.Close();
            
            return RedirectToAction("ListaPrenotazioni");
        }

        public ActionResult ModificaPrenotazioni(int id)
        {
            ViewBag.ListaClienti = Cliente.ListaClienti;
            ViewBag.ListaSoggiorni = Soggiorno.ListaSoggiorni;
            ViewBag.ListaCamere = Camera.ListaCamere;

            SqlConnection con = Connessione.GetConnectionDB();
            Prenotazione prenotazione = new Prenotazione();
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand();
                command.Parameters.AddWithValue("@IDPrenotazione", id);
                command.CommandText = "SELECT * FROM Prenotazioni INNER JOIN Clienti ON Prenotazioni.IDCliente = Clienti.IDCliente INNER JOIN Camere ON Prenotazioni.IDCamera = Camere.IDCamera INNER JOIN Soggiorni ON Prenotazioni.IDSoggiorno = Soggiorni.IDSoggiorno WHERE IDPrenotazione = @IDPrenotazione";
                command.Connection = con;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Cliente clienti = new Cliente();
                    clienti.IDCliente = Convert.ToInt32(reader["IDCliente"]);
                    clienti.Nome = reader["Nome"].ToString();
                    clienti.Cognome = reader["Cognome"].ToString();
                    clienti.CodiceFiscale = reader["CodiceFiscale"].ToString();
                    Camera camera = new Camera();
                    camera.Id = Convert.ToInt32(reader["IDCamera"]);
                    camera.NumeroCamera = Convert.ToInt32(reader["NumeroCamera"]);
                    Soggiorno soggiorno = new Soggiorno();
                    soggiorno.IDSoggiorno = Convert.ToInt32(reader["IDSoggiorno"]);
                    soggiorno.TipoSoggiorno = reader["TipoSoggiorno"].ToString();
                    prenotazione.ID = Convert.ToInt32(reader["IDPrenotazione"]);
                    prenotazione.DataPrenotazione = Convert.ToDateTime(reader["DataPrenotazione"]);
                    prenotazione.DataInizio = Convert.ToDateTime(reader["Datainizio"]);
                    prenotazione.DataFine = Convert.ToDateTime(reader["DataFine"]);
                    prenotazione.Caparra = Convert.ToDecimal(reader["Caparra"]);
                    prenotazione.Totale = Convert.ToDecimal(reader["Totale"]);
                    prenotazione.Cliente = clienti;
                    prenotazione.Camera = camera;
                    prenotazione.Soggiorno = soggiorno;


                }
            }
            catch (Exception ex)
            {

            }
            con.Close();




            return View(prenotazione);
        }

        [HttpPost]
        public ActionResult ModificaPrenotazioni(Prenotazione prenotazione)
        {
            SqlConnection con = Connessione.GetConnectionDB();
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE Prenotazioni SET IDCliente = @IDCliente, IDCamera = @IDCamera, DataPrenotazione = @DataPrenotazione, DataInizio = @DataInizio, DataFine = @DataFine, Caparra = @Caparra, Totale = @Totale, IDSoggiorno = @IDSoggiorno WHERE IDPrenotazione = @IDPrenotazione", con);
                command.Parameters.AddWithValue("@IDPrenotazione", prenotazione.ID);
                command.Parameters.AddWithValue("@IDCliente", prenotazione.IDCliente);
                command.Parameters.AddWithValue("@IDCamera", prenotazione.IDCamera);
                command.Parameters.AddWithValue("@DataPrenotazione", prenotazione.DataPrenotazione);
                command.Parameters.AddWithValue("@DataInizio", prenotazione.DataInizio);
                command.Parameters.AddWithValue("@DataFine", prenotazione.DataFine);
                command.Parameters.AddWithValue("@Caparra", prenotazione.Caparra);
                command.Parameters.AddWithValue("@Totale", prenotazione.Totale);
                command.Parameters.AddWithValue("@IDSoggiorno", prenotazione.IDSoggiorno);

                command.ExecuteNonQuery();


            }
            catch (Exception ex)
            {

            }
            con.Close();

            return RedirectToAction("ListaPrenotazioni");
        }

        public ActionResult ListaServizi(int id)
        {
            ServizioAggiuntivo.listaServizi.Clear();
            SqlConnection con = Connessione.GetConnectionDB();

            try
            {
                con.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM ServiziAggiuntivi WHERE IDPrenotazione = @IDPrenotazione", con);
                command.Parameters.AddWithValue("@IDPrenotazione", id);
                SqlDataReader reader= command.ExecuteReader();
                while (reader.Read())
                {
                    ServizioAggiuntivo servizio = new ServizioAggiuntivo();
                    servizio.Id = Convert.ToInt32(reader["IdServizio"]);
                    servizio.DescrizioneServizio = reader["DescrizioneServizio"].ToString();
                    servizio.CostoServizio = Convert.ToDecimal(reader["CostoServizio"]);
                    servizio.DataServizio = Convert.ToDateTime(reader["DataServizio"]);
                    servizio.IDPrenotazione = Convert.ToInt32(reader["IDPrenotazione"]);
                    ServizioAggiuntivo.listaServizi.Add(servizio);

                }
            }catch(Exception ex)
            {

            }
            con.Close();
            
            
            return View(ServizioAggiuntivo.listaServizi);
        }

        public ActionResult AggiungiServizi()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AggiungiServizi(ServizioAggiuntivo servizio, int id)
        {
            SqlConnection con = Connessione.GetConnectionDB();
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand("INSERT INTO ServiziAggiuntivi VALUES (@DescrizioneServizio, @CostoServizio, @DataServizio, @IDPrenotazione)", con);
                command.Parameters.AddWithValue("@DescrizioneServizio", servizio.DescrizioneServizio);
                command.Parameters.AddWithValue("@CostoServizio", servizio.CostoServizio);
                command.Parameters.AddWithValue("@DataServizio", servizio.DataServizio);
                command.Parameters.AddWithValue("@IDPrenotazione", id);

                command.ExecuteNonQuery();


            }catch(Exception ex)
            {

            }
            con.Close();
            
            return View();
        }

        public ActionResult CheckOut(int id)
        {
            ContoTotale.listaConto.Clear();
            SqlConnection con = Connessione.GetConnectionDB();
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand("SELECT SUM(CostoServizio) AS TotaleServizi, Totale, Caparra FROM ServiziAggiuntivi INNER JOIN Prenotazioni ON ServiziAggiuntivi.IDPrenotazione = Prenotazioni.IDPrenotazione WHERE ServiziAggiuntivi.IDPrenotazione = @IDPrenotazione GROUP BY Totale, Caparra", con);
                command.Parameters.AddWithValue("@IDPrenotazione", id);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ContoTotale conto = new ContoTotale();
                    conto.TotaleServizi = Convert.ToDecimal(reader["TotaleServizi"]);
                    conto.CaparraVersata = Convert.ToDecimal(reader["Caparra"]);
                    conto.TotalePrenotazione = Convert.ToDecimal(reader["Totale"]);
                    conto.TotaleEffettivo = conto.TotaleServizi + conto.TotalePrenotazione - conto.CaparraVersata;
                    
                    ContoTotale.listaConto.Add(conto);
                }
            }catch (Exception ex)
            {

            }
            con.Close();
            
            return View(ContoTotale.listaConto);
        }

        public ActionResult PrenotazioniPerCliente()
        {
            return View();
        }

        public JsonResult GetPrenotazioni(string CF)
        {
            Prenotazione.listaPrenotazioni.Clear();
            SqlConnection con = Connessione.GetConnectionDB();
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Prenotazioni INNER JOIN Clienti ON Prenotazioni.IDCliente = Clienti.IDCliente WHERE CodiceFiscale = @CodiceFiscale", con);
                command.Parameters.AddWithValue("@CodiceFiscale", CF);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Prenotazione prenotazione = new Prenotazione();
                    Cliente clienti = new Cliente();
                    clienti.IDCliente = Convert.ToInt32(reader["IDCliente"]);
                    clienti.Nome = reader["Nome"].ToString();
                    clienti.Cognome = reader["Cognome"].ToString();
                    clienti.CodiceFiscale = reader["CodiceFiscale"].ToString();
                    prenotazione.ID = Convert.ToInt32(reader["IDPrenotazione"]);
                    prenotazione.DataPrenotazione = Convert.ToDateTime(reader["DataPrenotazione"]);

                    prenotazione.Cliente = clienti;



                    Prenotazione.listaPrenotazioni.Add(prenotazione);
                }
            }
            catch (Exception ex)
            {

            }
            con.Close();


            return Json(Prenotazione.listaPrenotazioni, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPrenotazioniPensione(int Pensione)
        {
            Prenotazione.listaPrenotazioni.Clear();
            SqlConnection con = Connessione.GetConnectionDB();
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Prenotazioni INNER JOIN Clienti ON Prenotazioni.IDCliente = Clienti.IDCliente INNER JOIN Soggiorni ON Prenotazioni.IDSoggiorno = Soggiorni.IDSoggiorno WHERE Prenotazioni.IDSoggiorno = @IDSoggiorno", con);
                command.Parameters.AddWithValue("@IDSoggiorno", Pensione);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Prenotazione prenotazione = new Prenotazione();
                    Cliente clienti = new Cliente();
                    clienti.IDCliente = Convert.ToInt32(reader["IDCliente"]);
                    clienti.Nome = reader["Nome"].ToString();
                    clienti.Cognome = reader["Cognome"].ToString();
                    clienti.CodiceFiscale = reader["CodiceFiscale"].ToString();
                    Soggiorno soggiorno = new Soggiorno();
                    soggiorno.IDSoggiorno = Convert.ToInt32(reader["IDSoggiorno"]);
                    soggiorno.TipoSoggiorno = reader["TipoSoggiorno"].ToString();
                    prenotazione.ID = Convert.ToInt32(reader["IDPrenotazione"]);
                    prenotazione.DataPrenotazione = Convert.ToDateTime(reader["DataPrenotazione"]);

                    prenotazione.Cliente = clienti;
                    prenotazione.Soggiorno = soggiorno;



                    Prenotazione.listaPrenotazioni.Add(prenotazione);
                }
            }
            catch (Exception ex)
            {

            }
            con.Close();


            return Json(Prenotazione.listaPrenotazioni, JsonRequestBehavior.AllowGet);
        }
    }
}