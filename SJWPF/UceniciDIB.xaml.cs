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
    /// Interaction logic for UceniciDIB.xaml
    /// </summary>
    public partial class UceniciDIB : Window
    {
        private CollectionViewSource cvs;
        public UceniciDIB()
        {
            InitializeComponent();
            btnKursevi.IsEnabled = false;
            btnIzmeni.IsEnabled = false;
            btnIzbrisi.IsEnabled = false;
            cvs = new CollectionViewSource();
            cvs.Source = Aplikacija.Instanca.Ucenici;
            dgUcenici.ItemsSource = cvs.View;
            dgUcenici.IsReadOnly = true;
            dgUcenici.SelectionMode = DataGridSelectionMode.Single;
            dgUcenici.AutoGenerateColumns = false;

            DataGridTextColumn ime = new DataGridTextColumn();
            ime.Header = "Ime";
            ime.Binding = new Binding("Ime");

            DataGridTextColumn prezime = new DataGridTextColumn();
            prezime.Header = "Prezime";
            prezime.Binding = new Binding("Prezime");

            DataGridTextColumn jmbg = new DataGridTextColumn();
            jmbg.Header = "JMBG";
            jmbg.Binding = new Binding("JMBG");


            DataGridCheckBoxColumn status = new DataGridCheckBoxColumn();
            status.Header = "Status";
            status.Binding = new Binding("Status");


            DataGridTextColumn email = new DataGridTextColumn();
            email.Header = "Email";
            email.Binding = new Binding("Email");

            DataGridTextColumn adresa = new DataGridTextColumn();
            adresa.Header = "Adresa";
            adresa.Binding = new Binding("Adresa");

            DataGridTextColumn brTelefona = new DataGridTextColumn();
            brTelefona.Header = "Broj Telefona";
            brTelefona.Binding = new Binding("BrTelefona");

            dgUcenici.Columns.Add(ime);
            dgUcenici.Columns.Add(prezime);
            dgUcenici.Columns.Add(jmbg);
            dgUcenici.Columns.Add(status);
            dgUcenici.Columns.Add(email);
            dgUcenici.Columns.Add(adresa);
            dgUcenici.Columns.Add(brTelefona);
            





        }

        private void dgUcenici_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (IsLoaded)
            {
                btnIzbrisi.IsEnabled = true;
                btnIzmeni.IsEnabled = true;
                btnKursevi.IsEnabled = true;

            }
        }

        private void btnKursevi_Click(object sender, RoutedEventArgs e)
        {
            Ucenik u = dgUcenici.SelectedItem as Ucenik;
            UcProfPrikazKurseva upk = new UcProfPrikazKurseva(u.Kursevi);
            upk.ShowDialog();
        }

        private void btnUplate_Click(object sender, RoutedEventArgs e)
        {
            Ucenik u = dgUcenici.SelectedItem as Ucenik;
            UcProfPrikazUplata upu = new UcProfPrikazUplata(u.Uplate);
            upu.ShowDialog();
        }

        private void btnIzbrisi_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Da li ste sigurni?", "Potvrda brisanja", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {

                Ucenik j = dgUcenici.SelectedItem as Ucenik;


                j.Status = false;

            }
        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            Ucenik u = dgUcenici.SelectedItem as Ucenik;
            UcenikIzmena ui = new UcenikIzmena(u, MOD.IZMENA);
            ui.ShowDialog();
        }

        private void btnDodavanje_Click(object sender, RoutedEventArgs e)
        {
            Ucenik u = new Ucenik();
            UcenikIzmena ui = new UcenikIzmena(u, MOD.DODAVANJE);
            ui.ShowDialog();
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

        private void rbIzbrisani_Checked(object sender, RoutedEventArgs e)
        {
            cvs.Filter += new FilterEventHandler(Neaktivni);
        }

        private void rbSviUcenici_Checked(object sender, RoutedEventArgs e)
        {
            cvs.Filter += new FilterEventHandler(SviUcenici);
        }


        private void SviUcenici(object sender, FilterEventArgs e)
        {
            Ucenik j = e.Item as Ucenik;
            if (j != null)
            {
                e.Accepted = j.Status == true || j.Status == false;
            }
        }
        private void Aktivni(object sender, FilterEventArgs e)
        {
            Ucenik j = e.Item as Ucenik;
            if (j != null)
            {
                e.Accepted = j.Status == true;
            }
        }

        private void Neaktivni(object sender, FilterEventArgs e)
        {
            Ucenik j = e.Item as Ucenik;
            if (j != null)
            {
                e.Accepted = j.Status == false;
            }
        }


        private void PretragaIme(object sender, FilterEventArgs e)
        {
            Ucenik j = e.Item as Ucenik;
            if (j != null)
            {
                e.Accepted = j.Ime.ToLower().Contains(tbIme.Text.ToLower());
            }
        }


        private void PretragaPrezime(object sender, FilterEventArgs e)
        {
            Ucenik j = e.Item as Ucenik;
            if (j != null)
            {
                e.Accepted = j.Prezime.ToLower().Contains(tbPrezime.Text.ToLower());
            }
        }
    }
}
