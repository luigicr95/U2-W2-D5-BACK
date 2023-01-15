using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace U2_W2_D5_BACK.Models
{
    public class Connessione
    {
        public static SqlConnection GetConnectionDB()
        {
            string constring = ConfigurationManager.ConnectionStrings["ConToHotel"].ToString();
            SqlConnection con = new SqlConnection(constring);
            return con;
        }

        public static SqlDataReader GetReader(string commandtext, SqlConnection con)
        {
            SqlCommand command = new SqlCommand(commandtext, con);
            SqlDataReader reader = command.ExecuteReader();
            return reader;
        }
    }
}