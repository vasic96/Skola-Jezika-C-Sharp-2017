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
    public class KorisnikDAO
    {

        public static void Read()
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select * from KORISNIK";
                SqlDataAdapter sqlDA = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                sqlDA.Fill(ds, "korisnici");
                foreach (DataRow row in ds.Tables["korisnici"].Rows)
                {
                    Korisnik k = new Korisnik();
                    k.Id = (int)row["id"];
                    k.Ime = (string)row["ime"];
                    k.Prezime = (string)row["prezime"];
                    k.JMBG = (string)row["jmbg"];
                    k.Status = (bool)row["sts"];
                    k.KorisnickoIme = (string)row["kime"];
                    k.Lozinka = (string)row["lozinka"];
                    k.Uloga = (bool)row["uloga"];
                    Aplikacija.Instanca.Korisnici.Add(k);
                }
            }
        }

        public static void Create(Korisnik k)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "insert into Korisnik values(@id,@ime,@prezime,@jmbg,@sts,@kime,@lozinka,@uloga)";
                cmd.Parameters.Add(new SqlParameter("@id", k.Id));
                cmd.Parameters.Add(new SqlParameter("@ime", k.Ime));
                cmd.Parameters.Add(new SqlParameter("@prezime", k.Prezime));
                cmd.Parameters.Add(new SqlParameter("@jmbg", k.JMBG));
                cmd.Parameters.Add(new SqlParameter("@sts", k.Status));
                cmd.Parameters.Add(new SqlParameter("@kime", k.KorisnickoIme));
                cmd.Parameters.Add(new SqlParameter("@lozinka", k.Lozinka));
                cmd.Parameters.Add(new SqlParameter("@uloga", k.Uloga));

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


        public static void Update(Korisnik k)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"update Korisnik set id=@id,ime=@ime,prezime=@prezime,jmbg=@jmbg,sts=@sts,kime=@kime,lozinka=@lozinka,uloga=@uloga where id=@id";
                cmd.Parameters.Add(new SqlParameter("@id", k.Id));
                cmd.Parameters.Add(new SqlParameter("@ime", k.Ime));
                cmd.Parameters.Add(new SqlParameter("@prezime", k.Prezime));
                cmd.Parameters.Add(new SqlParameter("@jmbg", k.JMBG));
                cmd.Parameters.Add(new SqlParameter("@sts", k.Status));
                cmd.Parameters.Add(new SqlParameter("@kime", k.KorisnickoIme));
                cmd.Parameters.Add(new SqlParameter("@lozinka", k.Lozinka));
                cmd.Parameters.Add(new SqlParameter("@uloga", k.Uloga));

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

        public static void Brisanje(Korisnik k)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"update Korisnik set id=@id,sts=@sts where id=@id";
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
