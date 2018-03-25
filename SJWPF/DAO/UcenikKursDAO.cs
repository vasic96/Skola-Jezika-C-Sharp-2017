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
    public class UcenikKursDAO
    {

        public static void Read()
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select * from ucenikkurs";
                SqlDataAdapter sqlDA = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                sqlDA.Fill(ds, "jezici");
                foreach (DataRow row in ds.Tables["jezici"].Rows)
                {

                    Kurs k = Aplikacija.Instanca.GetKursById((int)row["kid"]);
                    Ucenik u = Aplikacija.Instanca.GetUcenikById((int)row["uid"]);

                    k.Ucenici.Add(u);
                    u.Kursevi.Add(k);


                }
            }
        }

        public static void UcenikUKurs(Kurs k, Ucenik n)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "insert into ucenikkurs values(@kid,@uid)";
                cmd.Parameters.Add(new SqlParameter("@kid", k.Id));
                cmd.Parameters.Add(new SqlParameter("@uid", n.Id));



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

        public static void UcenikIzKursa(Kurs k, Ucenik n)
        {


            using (SqlConnection conn = new SqlConnection(Aplikacija.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"delete ucenikkurs where kid=@kid and uid=@uid";

                cmd.Parameters.Add(new SqlParameter("@kid", k.Id));
                cmd.Parameters.Add(new SqlParameter("@uid", n.Id));

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
