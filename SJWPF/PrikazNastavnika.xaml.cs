using SJWPF.DAO;
using SJWPF.Klase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for PrikazNastavnika.xaml
    /// </summary>
    public partial class PrikazNastavnika : Window
    {
        private static Kurs k1;
        private static ObservableCollection<Nastavnik> nastavniciVanKursa = new ObservableCollection<Nastavnik>();
        private CollectionViewSource cvs;
        public PrikazNastavnika()
        {

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        public PrikazNastavnika(Kurs k)
        {
            InitializeComponent();
            nastavniciVanKursa.Clear();
            k1 = k;
            //if(k1.Ucenici.Count == 0)
            //{
            //    UceniciVanKursa = Aplikacija.Instanca.Ucenici;
            //}
            //else
            //{

            //}

            btnDodaj.IsEnabled = false;
            cvs = new CollectionViewSource();
            cvs.Source = k.Nastavnici;
            dgNastavnici.ItemsSource = cvs.View;
            dgNastavnici.IsReadOnly = true;
            dgNastavnici.SelectionMode = DataGridSelectionMode.Single;
            dgNastavnici.AutoGenerateColumns = false;
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


            DataGridTextColumn plata = new DataGridTextColumn();
            plata.Header = "Plata";
            plata.Binding = new Binding("Plata");

            DataGridTextColumn email = new DataGridTextColumn();
            email.Header = "Email";
            email.Binding = new Binding("Email");

            DataGridTextColumn adresa = new DataGridTextColumn();
            adresa.Header = "Adresa";
            adresa.Binding = new Binding("Adresa");

            DataGridTextColumn brTelefona = new DataGridTextColumn();
            brTelefona.Header = "Broj Telefona";
            brTelefona.Binding = new Binding("BrTelefona");

            dgNastavnici.Columns.Add(ime);
            dgNastavnici.Columns.Add(prezime);
            dgNastavnici.Columns.Add(jmbg);
            dgNastavnici.Columns.Add(status);
            dgNastavnici.Columns.Add(plata);
            dgNastavnici.Columns.Add(email);
            dgNastavnici.Columns.Add(adresa);
            dgNastavnici.Columns.Add(brTelefona);



        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {

            Nastavnik u = dgNastavnici.SelectedItem as Nastavnik;
            k1.Nastavnici.Add(u);
            nastavniciVanKursa.Remove(u);
            NastavnikKursDAO.NastavnikUKurs(k1, u);


        }

        private void cbVanKursa_Checked(object sender, RoutedEventArgs e)
        {
            btnDodaj.IsEnabled = true;
            btnIzbaci.IsEnabled = false;
            cvs = new CollectionViewSource();
            UceniciBezKursa1();
            cvs.Source = nastavniciVanKursa;
            dgNastavnici.ItemsSource = cvs.View;
            dgNastavnici.IsReadOnly = true;
            dgNastavnici.SelectionMode = DataGridSelectionMode.Single;

        }

        private void btnIzbaci_Click(object sender, RoutedEventArgs e)
        {
            Nastavnik u = dgNastavnici.SelectedItem as Nastavnik;
            k1.Nastavnici.Remove(u);
            nastavniciVanKursa.Add(u);
            NastavnikKursDAO.NastavnikIzKursa(k1, u);

        }

        public static void UceniciBezKursa1()
        {
            //UceniciVanKursa = Aplikacija.Instanca.Ucenici;
            foreach (Nastavnik u in Aplikacija.Instanca.Nastavnici)
            {
                if (!k1.Nastavnici.Contains(u) && u.Status == true)
                {
                    nastavniciVanKursa.Add(u);
                }
            }
        }

        private void cbVanKursa_Unchecked(object sender, RoutedEventArgs e)
        {

            btnDodaj.IsEnabled = false;
            btnIzbaci.IsEnabled = true;
            cvs = new CollectionViewSource();
            nastavniciVanKursa.Clear();
            cvs.Source = k1.Nastavnici;
            dgNastavnici.ItemsSource = cvs.View;
            dgNastavnici.IsReadOnly = true;
            dgNastavnici.SelectionMode = DataGridSelectionMode.Single;
        }
    }
}
