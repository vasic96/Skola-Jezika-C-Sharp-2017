using SJWPF.Klase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SJWPF.DAO
{
    public class SkolaDAO
    {


        public static void Read()
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select * from skola";
                SqlDataAdapter sqlDA = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                sqlDA.Fill(ds, "jezici");
                foreach (DataRow row in ds.Tables["jezici"].Rows)

                {
                    string naziv = (string)row["naziv"];
                    string adresa = (string)row["adresa"];
                    string web = (string)row["web"];
                    string email = (string)row["email"];
                    string ziro = (string)row["ziro"];
                    string mb = (string)row["mb"];
                    string pib = (string)row["pib"];

                    Aplikacija.Instanca.Skola = new Skola(naziv, adresa, web, email, ziro, mb, pib);

                }
            }
        }

        public static void Update(Skola k)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"update skola set naziv=@naziv,adresa=@adresa,web=@web,email=@email, ziro=@ziro, mb=@mb, pib=@pib where naziv=@naziv";
                cmd.Parameters.Add(new SqlParameter("@naziv", k.Naziv));
                cmd.Parameters.Add(new SqlParameter("@adresa", k.Adresa));
                cmd.Parameters.Add(new SqlParameter("@web", k.WebSajt));
                cmd.Parameters.Add(new SqlParameter("@email", k.Email));
                cmd.Parameters.Add(new SqlParameter("@ziro", k.ZiroRacun));
                cmd.Parameters.Add(new SqlParameter("@mb", k.MB));
                cmd.Parameters.Add(new SqlParameter("@pib", k.PIB));


                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException e)
                {

                    MessageBox.Show(e.Message, "nece", MessageBoxButton.OK);
                }

            }

        }
    }
}
