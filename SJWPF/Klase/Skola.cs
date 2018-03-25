using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJWPF.Klase
{
    public class Skola
    {
        private string naziv;
        public string Naziv
        {
            get { return naziv; }
            set { naziv = value; }
        }

        private string adresa;
        public string Adresa
        {
            get { return adresa; }
            set { adresa = value; }
        }

        private string webSajt;
        public string WebSajt
        {
            get { return webSajt; }
            set { webSajt = value; }

        }

        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }

        }

        private string ziroRacun;
        public string ZiroRacun
        {
            get { return ziroRacun; }
            set { ziroRacun = value; }
        }

        private string mb;
        public string MB
        {
            get { return mb; }
            set { mb = value; }
        }

        private string pib;
        public string PIB
        {
            get { return pib; }
            set { pib = value; }
        }
        public Skola()
        {

        }

        public Skola(string naziv, string adresa, string websajt, string email, string ziroRacun, string mb, string pib)
        {
            this.Naziv = naziv;
            this.Adresa = adresa;
            this.WebSajt = websajt;
            this.Email = email;
            this.ZiroRacun = ziroRacun;
            this.MB = mb;
            this.PIB = pib;
        }
    }
}
