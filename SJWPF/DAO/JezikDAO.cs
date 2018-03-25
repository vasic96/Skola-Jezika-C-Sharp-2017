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
    public class JezikDAO
    {

        public static void Read()
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select * from JEZIK";
                SqlDataAdapter sqlDA = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                sqlDA.Fill(ds, "jezici");
                foreach (DataRow row in ds.Tables["jezici"].Rows)
                {
                    Jezik k = new Jezik();
                    k.Id = (int)row["id"];
                    k.NazivJezika = (string)row["nazivjezika"];
                    k.Oznaka = (string)row["oznaka"];
                    k.Status = (bool)row["sts"];

                    Aplikacija.Instanca.Jezici.Add(k);
                }
            }
        }
        public static void Create(Jezik k)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "insert into Jezik values(@id,@nazivjezika,@oznaka,@sts)";
                cmd.Parameters.Add(new SqlParameter("@id", k.Id));
                cmd.Parameters.Add(new SqlParameter("@nazivjezika", k.NazivJezika));
                cmd.Parameters.Add(new SqlParameter("@oznaka", k.Oznaka));
                cmd.Parameters.Add(new SqlParameter("@sts", k.Status));


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
        public static void Update(Jezik k)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"update Jezik set id=@id,nazivjezika=@nazivjezika,oznaka=@oznaka,sts=@sts where id=@id";
                cmd.Parameters.Add(new SqlParameter("@id", k.Id));
                cmd.Parameters.Add(new SqlParameter("@nazivjezika", k.NazivJezika));
                cmd.Parameters.Add(new SqlParameter("@oznaka", k.Oznaka));
                cmd.Parameters.Add(new SqlParameter("@sts", k.Status));


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

        public static void Brisanje(Jezik k)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"update Jezik set id=@id,sts=@sts where id=@id";
                cmd.Parameters.Add(new SqlParameter("@id", k.Id));
                cmd.Parameters.Add(new SqlParameter("@sts", k.Status));


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
