using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJWPF.Klase
{
    public class Nastavnik: Osoba
    {

        public int Id { get; set; }



        private double plata;
        public double Plata
        {
            get { return plata; }
            set
            {
                plata = value;
                OnPropertyChanged("Plata");

            }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }

        private string adresa;
        public string Adresa
        {
            get { return adresa; }
            set
            {
                adresa = value;
                OnPropertyChanged("Adresa");
            }
        }

        private string brTelefona;
        public string BrTelefona
        {
            get { return brTelefona; }
            set
            {
                brTelefona = value;
                OnPropertyChanged("BrTelefona");
            }
        }

        private ObservableCollection<Kurs> kursevi;
        public ObservableCollection<Kurs> Kursevi
        {
            get { return kursevi; }
            set
            {
                kursevi = value;
                OnPropertyChanged("Kurs");
            }
        }

        public Nastavnik():base()
        {
            this.kursevi = new ObservableCollection<Kurs>();
        }

        public Nastavnik(string ime, string prezime, string jmbg, bool status, double plata, string email, string adresa, string brTelefona): base(ime, prezime, jmbg, status)
        {
            this.Plata = plata;
            this.Email = email;
            this.Adresa = adresa;
            this.BrTelefona = brTelefona;
            this.Kursevi = new ObservableCollection<Kurs>();

        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        internal void setValues(Nastavnik copyObj)
        {
            this.Ime = copyObj.Ime;
            this.Prezime = copyObj.Prezime;
            this.JMBG = copyObj.JMBG;
            this.Status = copyObj.Status;
            this.Plata = copyObj.Plata;
            this.Email = copyObj.Email;
            this.Adresa = copyObj.Adresa;
            this.BrTelefona = copyObj.BrTelefona;
            this.Kursevi = copyObj.Kursevi;
        }
    }
}
