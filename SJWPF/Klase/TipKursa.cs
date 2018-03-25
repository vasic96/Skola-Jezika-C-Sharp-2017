using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJWPF.Klase
{
    public class TipKursa: INotifyPropertyChanged
    {
        public int Id { get; set; }
        private string nivo;
        public string Nivo
        {
            get { return nivo; }
            set
            {
                
                
                nivo = value;
                OnPropertyChanged("Nivo");
            }

        }

        private string oznaka;
        public string Oznaka
        {
            get { return oznaka; }
            set
            {
                
                oznaka = value;
                OnPropertyChanged("Oznaka");
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

        public TipKursa()
        {
                
        }

        public TipKursa(string nivo, string oznaka, bool status)
        {
            this.Nivo = nivo;
            this.Oznaka = oznaka;
            this.Status = status;
                
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        protected void OnPropertyChanged(string propName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propName));
            }
        }
        public override string ToString()
        {
            return this.Oznaka;
        }
        internal void setValues(TipKursa copyObj)
        {
            this.Nivo = copyObj.Nivo;
            this.Oznaka = copyObj.Oznaka;
        }
    }
}
