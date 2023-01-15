using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using System.Web;

namespace U2_W2_D5_BACK.Models
{
    public class Camera
    {
        public int Id { get; set; }
        public int NumeroCamera { get; set; }
        public string DescrizioneCamera { get; set; }

        public static List<SelectListItem> ListaCamere
        {
            get
            {
                List<SelectListItem> selectList = new List<SelectListItem>();
                SqlConnection con = Connessione.GetConnectionDB();
                con.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Camere", con);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    SelectListItem camera = new SelectListItem
                    {
                        Text = reader["NumeroCamera"].ToString(),
                        Value = reader["IdCamera"].ToString()
                    };

                    selectList.Add(camera);
                }
                return selectList;
            }
        }
    }
}