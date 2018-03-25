using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJWPF.Klase
{
    public class Osoba : INotifyPropertyChanged
    {
        private string ime;

        public string Ime
        {
            get { return ime; }
            set
            {
                ime = value;
                OnPropertyChanged("Ime");
            }
        }

        private string prezime;
        public string Prezime
        {
            get { return prezime; }
            set
            {
                prezime = value;
                OnPropertyChanged("Prezime");
            }
        }
        private string jmbg;
        public string JMBG
        {
            get { return jmbg; }
            set
            {
                jmbg = value;
                OnPropertyChanged("JMBG");
            }
        }
        private bool status;
        public bool Status
        {
            get { return status; }
            set
            {
                status = value;
                OnPropertyChanged("Status");
            }
        }

        public Osoba()
        {

        }
        public Osoba(string ime, string prezime, string jmbg, bool status)
        {
            this.Ime = ime;
            this.Prezime = prezime;
            this.JMBG = jmbg;
            this.Status = status;
        }

        public override string ToString()
        {
            return this.Ime + " " + this.Prezime + this.jmbg;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
