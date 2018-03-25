using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJWPF.Klase
{
    public class Kurs : INotifyPropertyChanged

    {

        public int Id { get; set; }


        private Jezik jezik;
        public Jezik Jezik
        {
            get { return jezik; }
            set
            {
                jezik = value;
                OnPropertyChanged("Jezik");
            }
        }

        private TipKursa tipKursa;
        public TipKursa TipKursa
        {
            get { return tipKursa; }
            set
            {
                tipKursa = value;
                OnPropertyChanged("TipKursa");
            }
        }

        private double cena;
        public double Cena
        {
            get { return cena; }
            set
            {
                cena = value;
                OnPropertyChanged("Cena");
            }
        }

        private DateTime datumPocetak;
        public DateTime DatumPocetak
        {
            get { return datumPocetak; }
            set
            {
                datumPocetak = value;
                OnPropertyChanged("DatumPocetak");
            }
        }

        private DateTime datumKraj;
        public DateTime DatumKraj
        {
            get { return datumKraj; }
            set
            {
                datumKraj = value;
                OnPropertyChanged("DatumKraj");
            }
        }

        private ObservableCollection<Nastavnik> nastavnici;
        public ObservableCollection<Nastavnik> Nastavnici
        {
            get { return nastavnici; }
            set
            {
                nastavnici = value;
                OnPropertyChanged("Nastavnici");
            }
        }

        private ObservableCollection<Ucenik> ucenici;
        public ObservableCollection<Ucenik> Ucenici
        {
            get { return ucenici; }
            set
            {
                ucenici = value;
                OnPropertyChanged("Ucenici");
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


        private bool status;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool Status
        {
            get { return status; }
            set
            {
                status = value;
                OnPropertyChanged("Status");
            }
        }

        public Kurs()
        {
            this.Nastavnici = new ObservableCollection<Nastavnik>();
            this.Ucenici = new ObservableCollection<Ucenik>();
            this.Uplate = new ObservableCollection<Uplata>();

        }

        public Kurs(Jezik jezik, TipKursa tipKursa, double cena, DateTime datumPocetak, DateTime datumKraj, bool status)
        {

            this.Jezik = jezik;
            this.TipKursa = tipKursa;
            this.Cena = cena;
            this.DatumPocetak = datumPocetak;
            this.DatumKraj = datumKraj;
            this.Nastavnici = new ObservableCollection<Nastavnik>();
            this.Ucenici = new ObservableCollection<Ucenik>();
            this.Uplate = new ObservableCollection<Uplata>();
            this.Status = status;

        }

        protected void OnPropertyChanged(string propName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propName));
            }
        }


        public object Clone()
        {
            return this.MemberwiseClone();
        }

        internal void setValues(Kurs copyObj)
        {
           
            this.Jezik = copyObj.Jezik;
            this.TipKursa = copyObj.TipKursa;
            this.Cena = copyObj.Cena;
            this.DatumPocetak = copyObj.DatumPocetak;
            this.DatumKraj = copyObj.DatumKraj;
            this.Nastavnici = copyObj.Nastavnici;
            this.Ucenici = copyObj.Ucenici;
            this.Uplate = copyObj.Uplate;
            this.Status = copyObj.Status;
        }

        public override string ToString()
        {
            return this.Jezik.NazivJezika + " " + this.TipKursa.Oznaka;
        }
    }
}
