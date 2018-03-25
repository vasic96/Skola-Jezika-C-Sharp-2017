using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJWPF.Klase
{
    public class Uplata : INotifyPropertyChanged
    {


        private Ucenik ucenik;
        public Ucenik Ucenik
        {
            get { return ucenik; }
            set
            {
                ucenik = value;
                OnPropertyChanged("Ucenik");
            }
        }

        private Kurs kurs;
        public Kurs Kurs
        {
            get { return kurs; }
            set
            {
                kurs = value;
                OnPropertyChanged("Kurs");
            }
        }

        private DateTime datumUplate;

        public DateTime DatumUplate
        {
            get { return datumUplate; }
            set
            {
                datumUplate = value;
                OnPropertyChanged("DatumUplate");
            }
        }

        private bool statusUplate;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool StatusUplate
        {
            get { return statusUplate; }
            set
            {
                statusUplate = value;
                OnPropertyChanged("StatusUplate");
            }
        }
        public Uplata()
        {

        }

        public Uplata(Ucenik ucenik, Kurs kurs,DateTime datumUplate, bool statusUplate)
        {
            this.Ucenik = ucenik;
            this.Kurs = kurs;
            this.DatumUplate = datumUplate;
            this.StatusUplate = statusUplate;
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

        internal void setValues(Uplata copyObj)
        {
            this.Kurs = copyObj.Kurs;
            this.Ucenik = copyObj.Ucenik;
            this.DatumUplate = copyObj.DatumUplate;
            this.StatusUplate = copyObj.StatusUplate;
        }


    }
}
