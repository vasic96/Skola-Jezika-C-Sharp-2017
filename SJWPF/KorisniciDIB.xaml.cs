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
    /// Interaction logic for KorisniciDIB.xaml
    /// </summary>
    public partial class KorisniciDIB : Window
    {
        private CollectionViewSource cvs;
        public KorisniciDIB()
        {
            InitializeComponent();
            btnIzmena.IsEnabled = false;
            btnBrisanje.IsEnabled = false;
            cvs = new CollectionViewSource();
            cvs.Source = Aplikacija.Instanca.Korisnici;
            dgKorisnici.ItemsSource = cvs.View;
            dgKorisnici.IsReadOnly = true;
            dgKorisnici.SelectionMode = DataGridSelectionMode.Single;

        }

        private void dgKorisnici_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (IsLoaded)
            {
                btnIzmena.IsEnabled = true;
                btnBrisanje.IsEnabled = true;

            }

        }

        private void tbIme_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (IsLoaded)
            {
                cvs.Filter += new FilterEventHandler(PretragaIme);
            }


        }

        private void tbPrezime_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (IsLoaded)
            {
                cvs.Filter += new FilterEventHandler(PretragaPrezime);
            }
        }

        private void rbAktivni_Checked(object sender, RoutedEventArgs e)
        {
            cvs.Filter += new FilterEventHandler(Aktivni);
        }

        private void rbObrisani_Checked(object sender, RoutedEventArgs e)
        {
            cvs.Filter += new FilterEventHandler(Neaktivni);

        }

        private void rbSvi_Checked(object sender, RoutedEventArgs e)
        {
            if (IsLoaded)
            {
                cvs.Filter += new FilterEventHandler(SviKorisnici);
            }

        }

        private void btnDodavanje_Click(object sender, RoutedEventArgs e)
        {


            Korisnik j = new Korisnik();
            KorisnikIzmena ji = new KorisnikIzmena(j, MOD.DODAVANJE);
            ji.ShowDialog();


        }

        private void btnIzmena_Click(object sender, RoutedEventArgs e)
        {
            Korisnik j = dgKorisnici.SelectedItem as Korisnik;
            KorisnikIzmena ji = new KorisnikIzmena(j, MOD.IZMENA);
            ji.ShowDialog();
        }

        private void btnBrisanje_Click(object sender, RoutedEventArgs e)
        {

            if (MessageBox.Show("Da li ste sigurni?", "Potvrda brisanja", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {

                Korisnik j = dgKorisnici.SelectedItem as Korisnik;


                j.Status = false;

                btnBrisanje.IsEnabled = false;
                btnIzmena.IsEnabled = false;

                KorisnikDAO.Brisanje(j);
            }

        }

        private void SviKorisnici(object sender, FilterEventArgs e)
        {
            Korisnik j = e.Item as Korisnik;
            if (j != null)
            {
                e.Accepted = j.Status == true || j.Status == false;
            }
        }
        private void Aktivni(object sender, FilterEventArgs e)
        {
            Korisnik j = e.Item as Korisnik;
            if (j != null)
            {
                e.Accepted = j.Status == true;
            }
        }

        private void Neaktivni(object sender, FilterEventArgs e)
        {
            Korisnik j = e.Item as Korisnik;
            if (j != null)
            {
                e.Accepted = j.Status == false;
            }
        }


        private void PretragaIme(object sender, FilterEventArgs e)
        {
            Korisnik j = e.Item as Korisnik;
            if (j != null)
            {
                e.Accepted = j.Ime.ToLower().Contains(tbIme.Text.ToLower());
            }
        }


        private void PretragaPrezime(object sender, FilterEventArgs e)
        {
            Korisnik j = e.Item as Korisnik;
            if (j != null)
            {
                e.Accepted = j.Prezime.ToLower().Contains(tbPrezime.Text.ToLower());
            }
        }
    }
}
