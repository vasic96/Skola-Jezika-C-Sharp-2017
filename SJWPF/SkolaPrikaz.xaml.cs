using SJWPF.DAO;
using SJWPF.Klase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SJWPF
{
    /// <summary>
    /// Interaction logic for SkolaPrikaz.xaml
    /// </summary>
    public partial class SkolaPrikaz : Window
    {
        protected Skola skola;
        public SkolaPrikaz()
        {
            
        }

        public SkolaPrikaz(Skola s)
        {
            InitializeComponent();


            tbNaziv.Text = s.Naziv;
            tbAdresa.Text = s.Adresa;
            tbWebSajt.Text = s.WebSajt;
            tbEmail.Text = s.Email;
            tbZiroRacun.Text = s.ZiroRacun;
            tbMB.Text = s.MB;
            tbPIB.Text = s.PIB;


            tbNaziv.IsEnabled = false;
            tbAdresa.IsEnabled = false;
            tbWebSajt.IsEnabled = false;
            tbEmail.IsEnabled = false;
            tbZiroRacun.IsEnabled = false;
            tbMB.IsEnabled = false;
            tbPIB.IsEnabled = false;

            btnSacuvaj.IsEnabled = false;

           
        }

        private void cbIzmena_Checked(object sender, RoutedEventArgs e)
        {
            tbNaziv.IsEnabled = true;
            tbAdresa.IsEnabled = true;
            tbWebSajt.IsEnabled = true;
            tbEmail.IsEnabled = true;
            tbZiroRacun.IsEnabled = true;
            tbMB.IsEnabled = true;
            tbPIB.IsEnabled = true;

            btnSacuvaj.IsEnabled = true;
        }


        private void cbIzmena_Unchecked(object sender, RoutedEventArgs e)
        {
            tbNaziv.IsEnabled = false;
            tbAdresa.IsEnabled = false;
            tbWebSajt.IsEnabled = false;
            tbEmail.IsEnabled = false;
            tbZiroRacun.IsEnabled = false;
            tbMB.IsEnabled = false;
            tbPIB.IsEnabled = false;

            btnSacuvaj.IsEnabled = false;
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            Aplikacija.Instanca.Skola.Naziv = tbNaziv.Text;
            Aplikacija.Instanca.Skola.Adresa = tbAdresa.Text;
            Aplikacija.Instanca.Skola.WebSajt = tbWebSajt.Text;
            Aplikacija.Instanca.Skola.Email = tbEmail.Text;
            Aplikacija.Instanca.Skola.ZiroRacun = tbZiroRacun.Text;
            Aplikacija.Instanca.Skola.MB = tbMB.Text;
            Aplikacija.Instanca.Skola.PIB = tbPIB.Text;
            SkolaDAO.Update(Aplikacija.Instanca.Skola);
        }
    }
}
