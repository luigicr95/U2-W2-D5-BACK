using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace U2_W2_D5_BACK.Models
{
    public class Utenti
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public static bool Autenticazione(string username, string password)
        {
            SqlConnection con = Connessione.GetConnectionDB();
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Utenti WHERE  Username = @username AND [Password] = @password", con);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        
        }
    }
}