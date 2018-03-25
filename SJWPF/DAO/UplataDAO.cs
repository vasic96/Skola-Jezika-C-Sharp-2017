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
    public class UplataDAO
    {

        public static void Read()
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select * from uplata";
                SqlDataAdapter sqlDA = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                sqlDA.Fill(ds, "kursevi");
                foreach (DataRow row in ds.Tables["kursevi"].Rows)
                {
                    Uplata k = new Uplata();

                    k.Ucenik = Aplikacija.Instanca.GetUcenikById((int)row["uid"]);
                    k.Kurs = Aplikacija.Instanca.GetKursById((int)row["kid"]);
                    k.DatumUplate = (DateTime)row["datum"];

                    k.StatusUplate = (bool)row["sts"];



                    Aplikacija.Instanca.Uplate.Add(k);
                }

                foreach (Ucenik u in Aplikacija.Instanca.Ucenici)
                {
                    foreach (Uplata up in Aplikacija.Instanca.Uplate)
                    {
                        if(u.Id == up.Ucenik.Id)
                        {
                            u.Uplate.Add(up);
                        }
                    }
                }

                foreach (Kurs k in Aplikacija.Instanca.Kursevi)
                {
                    foreach (Uplata up in Aplikacija.Instanca.Uplate)
                    {
                        if(k.Id == up.Kurs.Id)
                        {
                            k.Uplate.Add(up);
                        }
                    }
                }
            }
        }


        public static void Create(Uplata k)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "insert into uplata values(@uid,@kid,@datum,@sts)";
                cmd.Parameters.Add(new SqlParameter("@uid", k.Ucenik.Id));
                cmd.Parameters.Add(new SqlParameter("@kid", k.Kurs.Id));
                cmd.Parameters.Add(new SqlParameter("@datum", k.DatumUplate));
                cmd.Parameters.Add(new SqlParameter("@sts", k.StatusUplate));


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



        public static void Uplati(Uplata k)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"update uplata set sts=@sts where uid=@uid and kid=@kid";
                cmd.Parameters.Add(new SqlParameter("@uid", k.Ucenik.Id));
                cmd.Parameters.Add(new SqlParameter("@kid", k.Kurs.Id));

                cmd.Parameters.Add(new SqlParameter("@sts", k.StatusUplate));


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

        public static void Delete(Uplata k)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "delete uplata where uid=@uid and kid=@kid";
                cmd.Parameters.Add(new SqlParameter("@uid", k.Ucenik.Id));
                cmd.Parameters.Add(new SqlParameter("@kid", k.Kurs.Id));
                


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
