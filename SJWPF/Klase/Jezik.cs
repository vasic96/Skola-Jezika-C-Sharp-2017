using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJWPF.Klase
{

    public class Jezik : INotifyPropertyChanged
    {
        public static string stnzv = "NazivJezika";
        public int Id { get; set; }
        private string nazivJezika;
        public string NazivJezika
        {
            get { return nazivJezika; }
            set
            {
               
                nazivJezika = value;
                OnPropertyChanged("NazivJEzika");
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
        public bool Status
        {
            get { return status; }
            set
            {
                status = value;
                OnPropertyChanged("Status");
            }
        }

        public Jezik()
        {
                
        }

        public Jezik(string nazivJezika, string oznaka, bool status)
        {
            this.nazivJezika = nazivJezika;
            this.oznaka = oznaka;
            this.Status = status;
        }

        public event PropertyChangedEventHandler PropertyChanged;
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
        internal void setValues(Jezik copyObj)
        {
            this.nazivJezika = copyObj.NazivJezika;
            this.Oznaka = copyObj.Oznaka;
        }

        public override string ToString()
        {
            return this.NazivJezika;
        }
    }
}
