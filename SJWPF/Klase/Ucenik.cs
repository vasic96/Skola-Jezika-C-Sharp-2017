using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJWPF.Klase
{
    public class Ucenik : Osoba
    {

        public int Id { get; set; }
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

        private ObservableCollection<Uplata> uplate;
        public ObservableCollection<Uplata> Uplate
        {
            get { return uplate; }
            set
            {
                uplate = value;
                OnPropertyChanged("Uplate");
            }
        }

        private ObservableCollection<Kurs> kursevi;
        public ObservableCollection<Kurs> Kursevi
        {
            get { return kursevi; }
            set
            {
                kursevi = value;
                OnPropertyChanged("Kursevi");
            }
        }


        public Ucenik() : base()
        {
            this.Uplate = new ObservableCollection<Uplata>();
            this.Kursevi = new ObservableCollection<Kurs>();
        }

        public Ucenik(string ime, string prezime, string jmbg, bool status, string email, string adresa, string brTelefona) : base(ime, prezime, jmbg, status)
        {
            this.Email = email;
            this.Adresa = adresa;
            this.BrTelefona = brTelefona;
            this.Uplate = new ObservableCollection<Uplata>();
            this.Kursevi = new ObservableCollection<Kurs>();



        }
        public override string ToString()
        {
            return this.Ime;
        }


        public object Clone()
        {
            return this.MemberwiseClone();
        }

        internal void setValues(Ucenik copyObj)
        {
            this.Ime = copyObj.Ime;
            this.Prezime = copyObj.Prezime;
            this.JMBG = copyObj.JMBG;
            this.Status = copyObj.Status;
            this.Email = copyObj.Email;
            this.Adresa = copyObj.Adresa;
            this.BrTelefona = copyObj.BrTelefona;
            this.Uplate = copyObj.Uplate;
            this.Kursevi = copyObj.Kursevi;
        }
    }
}
