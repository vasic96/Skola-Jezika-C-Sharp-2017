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
    public class UcenikDAO
    {
        public static void Read()
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select * from ucenik";
                SqlDataAdapter sqlDA = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                sqlDA.Fill(ds, "ucenici");
                foreach (DataRow row in ds.Tables["ucenici"].Rows)
                {
                    Ucenik k = new Ucenik();
                    k.Id = (int)row["id"];
                    k.Ime = (string)row["ime"];
                    k.Prezime = (string)row["prezime"];
                    k.JMBG = (string)row["jmbg"];
                    k.Status = (bool)row["sts"];
                    k.Email = (string)row["email"];
                    k.Adresa = (string)row["adresa"];
                    k.BrTelefona = (string)row["brtelefona"];
                    Aplikacija.Instanca.Ucenici.Add(k);
                }
            }
        }

        public static void Create(Ucenik k)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "insert into ucenik values(@id,@ime,@prezime,@jmbg,@sts,@email,@adresa,@brtelefona)";
                cmd.Parameters.Add(new SqlParameter("@id", k.Id));
                cmd.Parameters.Add(new SqlParameter("@ime", k.Ime));
                cmd.Parameters.Add(new SqlParameter("@prezime", k.Prezime));
                cmd.Parameters.Add(new SqlParameter("@jmbg", k.JMBG));
                cmd.Parameters.Add(new SqlParameter("@sts", k.Status));
                cmd.Parameters.Add(new SqlParameter("@email", k.Email));
                cmd.Parameters.Add(new SqlParameter("@adresa", k.Adresa));
                cmd.Parameters.Add(new SqlParameter("@brtelefona", k.BrTelefona));

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

        public static void Update(Ucenik k)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "update ucenik set id=@id,ime=@ime,prezime=@prezime,jmbg=@jmbg,sts=@sts,email=@email,adresa=@adresa,brtelefona=@brtelefona where id=@id";
                cmd.Parameters.Add(new SqlParameter("@id", k.Id));
                cmd.Parameters.Add(new SqlParameter("@ime", k.Ime));
                cmd.Parameters.Add(new SqlParameter("@prezime", k.Prezime));
                cmd.Parameters.Add(new SqlParameter("@jmbg", k.JMBG));
                cmd.Parameters.Add(new SqlParameter("@sts", k.Status));
                cmd.Parameters.Add(new SqlParameter("@email", k.Email));
                cmd.Parameters.Add(new SqlParameter("@adresa", k.Adresa));
                cmd.Parameters.Add(new SqlParameter("@brtelefona", k.BrTelefona));

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

        public static void Brisanje(Ucenik k)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"update ucenik set id=@id,sts=@sts where id=@id";
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
