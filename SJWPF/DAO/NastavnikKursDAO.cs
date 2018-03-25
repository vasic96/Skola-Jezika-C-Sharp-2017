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
    public class NastavnikKursDAO
    {
        public static void Read()
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select * from nastavnikkurs";
                SqlDataAdapter sqlDA = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                sqlDA.Fill(ds, "jezici");
                foreach (DataRow row in ds.Tables["jezici"].Rows)
                {
                  
                    Kurs k = Aplikacija.Instanca.GetKursById((int)row["kid"]);
                    Nastavnik n = Aplikacija.Instanca.GetNastavnikById((int)row["nid"]);

                    k.Nastavnici.Add(n);
                    n.Kursevi.Add(k);


                }
            }
        }

        public static void NastavnikUKurs(Kurs k, Nastavnik n)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "insert into nastavnikkurs values(@kid,@nid)";
                cmd.Parameters.Add(new SqlParameter("@kid", k.Id));
                cmd.Parameters.Add(new SqlParameter("@nid", n.Id));



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

        public static void NastavnikIzKursa(Kurs k, Nastavnik n)
        {


            using (SqlConnection conn = new SqlConnection(Aplikacija.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"delete nastavnikkurs where kid=@kid and nid=@nid";

                cmd.Parameters.Add(new SqlParameter("@kid", k.Id)); 
                cmd.Parameters.Add(new SqlParameter("@nid", n.Id));

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message, "Greska", MessageBoxButton.OK);
                }

            }
        }
    }
}
