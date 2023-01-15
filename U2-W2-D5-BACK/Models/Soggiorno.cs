using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using System.Web;

namespace U2_W2_D5_BACK.Models
{
    public class Soggiorno
    {
        public int IDSoggiorno { get; set; }
        public string TipoSoggiorno { get; set; }

        public static List<SelectListItem> ListaSoggiorni
        {
            get
            {
                List<SelectListItem> selectList = new List<SelectListItem>();
                SqlConnection con = Connessione.GetConnectionDB();
                con.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Soggiorni", con);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    SelectListItem soggiorno = new SelectListItem
                    {
                        Text = reader["TipoSoggiorno"].ToString(),
                        Value = reader["IdSoggiorno"].ToString()
                    };

                    selectList.Add(soggiorno);
                }
                return selectList;
            }

        }
    }
}