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
   public class KursDAO
    {
        public static void Read()
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select * from KURS";
                SqlDataAdapter sqlDA = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                sqlDA.Fill(ds, "kursevi");
                foreach (DataRow row in ds.Tables["kursevi"].Rows)
                {
                    Kurs k = new Kurs();
                    k.Id = (int)row["id"];
                    
                    k.Jezik = Aplikacija.Instanca.GetJEzikById((int)row["jezikid"]);
                    k.TipKursa = Aplikacija.Instanca.GetTipKursaById((int)row["tipid"]);
                    k.Cena = (double)row["cena"];
                    k.DatumPocetak = (DateTime)row["datpoc"];
                    k.DatumKraj = (DateTime)row["datkraj"];
                    k.Status = (bool)row["sts"];

                   

                    Aplikacija.Instanca.Kursevi.Add(k);
                }
            }
        }


        public static void Create(Kurs k)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "insert into kurs values(@id,@jezikid,@tipid,@cena,@datpoc,@datkraj,@sts)";
                cmd.Parameters.Add(new SqlParameter("@id", k.Id));
                cmd.Parameters.Add(new SqlParameter("@jezikid", k.Jezik.Id));
                cmd.Parameters.Add(new SqlParameter("@tipid", k.TipKursa.Id));
                cmd.Parameters.Add(new SqlParameter("@cena", k.Cena));
                cmd.Parameters.Add(new SqlParameter("@datpoc", k.DatumPocetak));
                cmd.Parameters.Add(new SqlParameter("@datkraj", k.DatumKraj));
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


        public static void Update(Kurs k)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"update kurs set id=@id,cena=@cena,datpoc=@datpoc,datkraj=@datkraj,sts=@sts where id=@id";
                cmd.Parameters.Add(new SqlParameter("@id", k.Id));
                cmd.Parameters.Add(new SqlParameter("@cena", k.Cena));
                cmd.Parameters.Add(new SqlParameter("@datpoc", k.DatumPocetak));
                cmd.Parameters.Add(new SqlParameter("@datkraj", k.DatumKraj));
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

        public static void Brisanje(Kurs k)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"update kurs set id=@id,sts=@sts where id=@id";
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
