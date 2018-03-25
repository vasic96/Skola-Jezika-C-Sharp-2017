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
    /// Interaction logic for PrikazUcenika.xaml
    /// </summary>
    public partial class PrikazUcenika : Window
    {
        private static Uplata uplata;
        private static Kurs k1;
        private static ObservableCollection<Ucenik> UceniciVanKursa = new ObservableCollection<Ucenik>();
         private CollectionViewSource cvs;
        public PrikazUcenika()
        {
            
        }



        public static void UceniciBezKursa1()
        {
            //UceniciVanKursa = Aplikacija.Instanca.Ucenici;
            foreach (Ucenik u in Aplikacija.Instanca.Ucenici)
            {
                if (!k1.Ucenici.Contains(u) && u.Status == true)
                {
                    UceniciVanKursa.Add(u);
                }
            }
        }

        public PrikazUcenika(Kurs k )
        {
            InitializeComponent();
            UceniciVanKursa.Clear();
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
            cvs.Source = k.Ucenici;
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

        private void cbVanKursa_Checked(object sender, RoutedEventArgs e)
        {
            btnDodaj.IsEnabled = true;
            btnIzbaci.IsEnabled = false;
            btnUplata.IsEnabled = false;
            cvs = new CollectionViewSource();
            UceniciBezKursa1();
            cvs.Source = UceniciVanKursa;
            dgUcenici.ItemsSource = cvs.View;
            dgUcenici.IsReadOnly = true;
            dgUcenici.SelectionMode = DataGridSelectionMode.Single;

        }



        private void cbVanKursa_Unchecked(object sender, RoutedEventArgs e)
        {

            btnDodaj.IsEnabled = false;
            btnIzbaci.IsEnabled = true;
            btnUplata.IsEnabled = true;
            cvs = new CollectionViewSource();
            UceniciVanKursa.Clear();
            cvs.Source = k1.Ucenici ;
            dgUcenici.ItemsSource = cvs.View;
            dgUcenici.IsReadOnly = true;
            dgUcenici.SelectionMode = DataGridSelectionMode.Single;
        }

        private void btnIzbaci_Click(object sender, RoutedEventArgs e)
        {
            Ucenik u = dgUcenici.SelectedItem as Ucenik;
            u.Uplate.Remove(uplata);
   //         Aplikacija.Instanca.Uplate.Remove(uplata);
            k1.Ucenici.Remove(u);
            UceniciVanKursa.Add(u);
            UcenikKursDAO.UcenikIzKursa(k1, u);
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            Ucenik u = dgUcenici.SelectedItem as Ucenik;
            // uplata = new Uplata();
          //  int id = Aplikacija.Instanca.Uplate.Count + 1;
            //uplata = new Uplata(u, k1, false);
            //uplata.Id = id;
            //u.Uplate.Add(uplata);
           // Aplikacija.Instanca.Uplate.Add(uplata);
            k1.Ucenici.Add(u);
            UceniciVanKursa.Remove(u);
            UcenikKursDAO.UcenikUKurs(k1, u);
            //UplataDAO.Create(uplata);

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
          //  UceniciVanKursa.Clear();
        }

        private void btnUplata_Click(object sender, RoutedEventArgs e)
        {
            Ucenik ucenik = dgUcenici.SelectedItem as Ucenik;
            
            
              if(ProveriUplate(k1, ucenik) == true)
            {
                Uplata uplata = new Uplata(ucenik, k1, DateTime.Now, false);
                Aplikacija.Instanca.Uplate.Add(uplata);
                k1.Uplate.Add(uplata);
                ucenik.Uplate.Add(uplata);
                UplataDAO.Create(uplata);

            }
            else
            {
                MessageBox.Show("Uplata vec postoji");
            }
        }


        public static bool ProveriUplate(Kurs k, Ucenik u)
        {
            foreach (Uplata uplata in Aplikacija.Instanca.Uplate)
            {
                if (k == uplata.Kurs && u == uplata.Ucenik)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
