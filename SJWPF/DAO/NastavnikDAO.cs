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
    public class NastavnikDAO
    {

        public static void Read()
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select * from nastavnik";
                SqlDataAdapter sqlDA = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                sqlDA.Fill(ds, "nastavnici");
                foreach (DataRow row in ds.Tables["nastavnici"].Rows)
                {
                    Nastavnik k = new Nastavnik();
                    k.Id = (int)row["id"];
                    k.Ime = (string)row["ime"];
                    k.Prezime = (string)row["prezime"];
                    k.JMBG = (string)row["jmbg"];
                    k.Status = (bool)row["sts"];
                    k.Plata = (double)row["plata"];
                    k.Email = (string)row["email"];
                    k.Adresa = (string)row["adresa"];
                    k.BrTelefona = (string)row["brtelefona"];
                    Aplikacija.Instanca.Nastavnici.Add(k);
                }
            }
        }

        public static void Create(Nastavnik k)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "insert into Nastavnik values(@id,@ime,@prezime,@jmbg,@sts,@plata,@email,@adresa,@brtelefona)";
                cmd.Parameters.Add(new SqlParameter("@id", k.Id));
                cmd.Parameters.Add(new SqlParameter("@ime", k.Ime));
                cmd.Parameters.Add(new SqlParameter("@prezime", k.Prezime));
                cmd.Parameters.Add(new SqlParameter("@jmbg", k.JMBG));
                cmd.Parameters.Add(new SqlParameter("@sts", k.Status));
                cmd.Parameters.Add(new SqlParameter("@plata", k.Plata));
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

        public static void Update(Nastavnik k)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "update Nastavnik set id=@id,ime=@ime,prezime=@prezime,jmbg=@jmbg,sts=@sts,plata=@plata,email=@email,adresa=@adresa,brtelefona=@brtelefona where id=@id";
                cmd.Parameters.Add(new SqlParameter("@id", k.Id));
                cmd.Parameters.Add(new SqlParameter("@ime", k.Ime));
                cmd.Parameters.Add(new SqlParameter("@prezime", k.Prezime));
                cmd.Parameters.Add(new SqlParameter("@jmbg", k.JMBG));
                cmd.Parameters.Add(new SqlParameter("@sts", k.Status));
                cmd.Parameters.Add(new SqlParameter("@plata", k.Plata));
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

        public static void Brisanje(Nastavnik k)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"update nastavnik set id=@id,sts=@sts where id=@id";
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
