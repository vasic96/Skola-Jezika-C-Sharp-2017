using SJWPF.Klase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJWPF
{
    public class Aplikacija
    {
        public const string CONNECTION_STRING = @"data source=.\SQLEXPRESS;initial catalog=SJWPF;integrated security=true;";
        public ObservableCollection<Korisnik> Korisnici { get; set; }
        public ObservableCollection<Ucenik> Ucenici { get; set; }
        public ObservableCollection<Nastavnik> Nastavnici { get; set; }
        public ObservableCollection<Jezik> Jezici { get; set; }
        public ObservableCollection<TipKursa> Tipovi { get; set; }
        public ObservableCollection<Kurs> Kursevi { get; set; }
        public ObservableCollection<Uplata> Uplate { get; set; }
        public Skola Skola { get; set; }

        private static Aplikacija instanca = new Aplikacija();
        public static Aplikacija Instanca
        {
            get { return instanca; }
        }

        private Aplikacija()
        {
            Skola = new Skola();
            Korisnici = new ObservableCollection<Korisnik>();
            Ucenici = new ObservableCollection<Ucenik>();
            Nastavnici = new ObservableCollection<Nastavnik>();
            Jezici = new ObservableCollection<Jezik>();
            Tipovi = new ObservableCollection<TipKursa>();
            Kursevi = new ObservableCollection<Kurs>();
            Uplate = new ObservableCollection<Uplata>();
            init();
        }

        private void init()
        {

    //        Skola = new Skola("Skola", "Ns", "skola.com", "skola@uciti.yu", "12345", "11", "123456");









        }

        public TipKursa GetTipKursaById(long id)
        {
            TipKursa retVal = null;
            foreach (TipKursa j in Tipovi)
            {
                if (j.Id == id)
                {
                    retVal = j;
                    break;
                }
                
            }
            return retVal;
        }

        public Jezik GetJEzikById(long id)
        {
            Jezik retVal = null;
            foreach (Jezik j in Jezici)
            {
                if (j.Id == id)
                {
                    retVal = j;
                    break;
                }

            }
            return retVal;
        }
        public Kurs GetKursById(long id)
        {
            Kurs retVal = null;
            foreach (Kurs j in Kursevi)
            {
                if (j.Id == id)
                {
                    retVal = j;
                    break;
                }

            }
            return retVal;
        }

        public Nastavnik GetNastavnikById(long id)
        {
            Nastavnik retVal = null;
            foreach (Nastavnik j in Nastavnici)
            {
                if (j.Id == id)
                {
                    retVal = j;
                    break;
                }

            }
            return retVal;
        }

        public Ucenik GetUcenikById(long id)
        {
            Ucenik retVal = null;
            foreach (Ucenik j in Ucenici)
            {
                if (j.Id == id)
                {
                    retVal = j;
                    break;
                }

            }
            return retVal;
        }


        public Korisnik login(string korisnickoIme, string lozinka)
        {
            Korisnik korisnik = null;
            
            foreach (Korisnik k in Korisnici)
            {
                if (k.KorisnickoIme == korisnickoIme && k.Lozinka == lozinka)
                {
                    
                    korisnik = k;
                }

            }

            return korisnik;
        }
    }
}


    

    

