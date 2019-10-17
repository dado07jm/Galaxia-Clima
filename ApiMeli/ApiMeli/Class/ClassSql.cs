using ApiMeli.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ApiMeli.Class
{
    public class ClassSql
    {
        private String con()
        {
            return " Server = tcp:************,1433; Initial Catalog = ***********; Persist Security Info = False;" +
                " User ID = *********; Password =***********; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
        }

        public String diaparticular (int dia)
        {
            String obtenerdia = "";
            Models.Clima cl = new Models.Clima();

            SqlConnection cnn = new SqlConnection(con());
            cnn.Open();
            SqlCommand query = new SqlCommand("Select dia,clima from clima where dia=" + dia + "", cnn);
            SqlDataReader dr;
            dr = query.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    cl.dia = Convert.ToInt32(dr[0].ToString());
                    cl.clima = dr[1].ToString();
                }
                obtenerdia = JsonConvert.SerializeObject(cl);
            }
            else
            {
                obtenerdia = "No hay registro para esa consulta";
            }
            return obtenerdia;

        }

        public String diaSequia()
        {
            String diaSequia = "";
            
            SqlConnection cnn = new SqlConnection(con());
            cnn.Open();
            SqlCommand query = new SqlCommand("Select clima, count(*) from clima group by clima having clima='Sequía'", cnn);
            SqlDataReader dr;
            dr = query.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    diaSequia = "Total de días de sequía: " + dr[1].ToString();
                }
            }
            else
            {
                diaSequia = "No hay días de sequía";
            }
            return diaSequia;

        }


        public String diaLluvia()
        {
            String diaLluvia = "";

            SqlConnection cnn = new SqlConnection(con());
            cnn.Open();
            SqlCommand query = new SqlCommand("Select clima, count(*) from clima group by clima having clima='Lluvia'", cnn);
            SqlDataReader dr;
            dr = query.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    diaLluvia = "Total de días de lluvia: " + dr[1].ToString();
                }
            }
            else
            {
                diaLluvia = "No hay días de sequía";
            }
            return diaLluvia;

        }

        public String PicosLluvia()
        {
            String diaLluvia = "";
            String sqlquery = @"declare @val int; set @val = (select top 1 count(*) from clima group by perimetro order by perimetro desc); select TOP(@val) dia from clima order by perimetro desc";
            SqlConnection cnn = new SqlConnection(con());
            cnn.Open();
            
            SqlCommand query = new SqlCommand(sqlquery, cnn);
            SqlDataReader dr;
            dr = query.ExecuteReader();

            if (dr.HasRows)
            {
                diaLluvia = "Los días con picos máximos de lluvia son: ";
                while (dr.Read())
                {
                    diaLluvia+= dr[0].ToString() + ", ";
                }
            }
            else
            {
                diaLluvia = "No hay días de sequía";
            }
            return diaLluvia;

        }




        public String diaOptimo()
        {
            String diaOptimo = "";

            SqlConnection cnn = new SqlConnection(con());
            cnn.Open();
            SqlCommand query = new SqlCommand("Select clima, count(*) from clima group by clima having clima='Optimo'", cnn);
            SqlDataReader dr;
            dr = query.ExecuteReader();

            if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        diaOptimo = "Total de días óptimos: " + dr[1].ToString();
                    }
            }
            else
            {
                diaOptimo = "No hay días de sequía";
            }
            return diaOptimo;

        }
    }
}