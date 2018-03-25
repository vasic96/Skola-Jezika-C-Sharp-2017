using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJWPF.Klase
{
    public class Korisnik : Osoba 
    {
        public int Id { get; set; }
        private string korisnickoIme;
        public string KorisnickoIme
        {
            get { return korisnickoIme; }
            set
            {
                korisnickoIme = value;
                OnPropertyChanged("KorisnickoIme");
            }
        }

        private string lozinka;
        public string Lozinka
        {
            get { return lozinka; }
            set
            {
                lozinka = value;
                OnPropertyChanged("Lozinka");

            }
        }

        private bool uloga;



        public bool Uloga
        {
            get { return uloga; }
            set
            {
                uloga = value;
                OnPropertyChanged("Uloga");

            }
        }


        public Korisnik() : base()
        {

        }

        public Korisnik(string ime, string prezime,  string jmbg, bool status, string korisnickoIme, string lozinka, bool uloga):base(ime, prezime, jmbg, status)
        {
            this.korisnickoIme = korisnickoIme;
            this.lozinka = lozinka;
            this.uloga = uloga;

        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }


        internal void setValues(Korisnik copyObj)
        {
            this.Ime = copyObj.Ime;
            this.Prezime = copyObj.Prezime;
            this.JMBG = copyObj.JMBG;
            this.Status = copyObj.Status;
            this.KorisnickoIme = copyObj.KorisnickoIme;
            this.Lozinka = copyObj.Lozinka;
            this.Uloga = copyObj.Uloga;
        }
    }
}
