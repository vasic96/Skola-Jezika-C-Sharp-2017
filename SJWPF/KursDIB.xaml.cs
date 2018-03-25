using SJWPF.DAO;
using SJWPF.Klase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for KursDIB.xaml
    /// </summary>
    public partial class KursDIB : Window
    {
        private CollectionViewSource cvs;
        private Kurs kurs;
        public KursDIB()
        {
            InitializeComponent();
            kurs = new Kurs();
            btnBrisanje.IsEnabled = false;
            btnIzmena.IsEnabled = false;
            btnUcenici.IsEnabled = false;
            btnNastavnici.IsEnabled = false;
            btnUplate.IsEnabled = false;
            cvs = new CollectionViewSource();
            cvs.Source = Aplikacija.Instanca.Kursevi;
          
            dgKursevi.ItemsSource = cvs.View;
            dgKursevi.IsReadOnly = true;
            dgKursevi.SelectionMode = DataGridSelectionMode.Single;
            dgKursevi.AutoGenerateColumns = false;

            DataGridTextColumn jezik = new DataGridTextColumn();
            jezik.Header = "Jezik";
            jezik.Binding = new Binding("Jezik");

            DataGridTextColumn tip = new DataGridTextColumn();
            tip.Header = "Tip Kursa";
            tip.Binding = new Binding("TipKursa");

            DataGridTextColumn cena = new DataGridTextColumn();
            cena.Header = "Cena";
            cena.Binding = new Binding("Cena");

            DataGridTextColumn dp = new DataGridTextColumn();
            dp.Header = "Datum pocetka";
            dp.Binding = new Binding("DatumPocetak");

            DataGridTextColumn dk= new DataGridTextColumn();
            dk.Header = "Datum Kraj";
            dk.Binding = new Binding("DatumKraj");

            DataGridCheckBoxColumn status = new DataGridCheckBoxColumn();
            status.Header = "Status";
            status.Binding = new Binding("Status");

            dgKursevi.Columns.Add(jezik);
            dgKursevi.Columns.Add(tip);
            dgKursevi.Columns.Add(cena);
            dgKursevi.Columns.Add(dp);
            dgKursevi.Columns.Add(dk);
            dgKursevi.Columns.Add(status);

        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (IsLoaded)
            {
                this.kurs = dgKursevi.SelectedItem as Kurs;
                btnIzmena.IsEnabled = true;
                btnBrisanje.IsEnabled = true;
                btnUcenici.IsEnabled = true;
                btnNastavnici.IsEnabled = true;
                btnUplate.IsEnabled = true;

            }
        }



        private void rbAktivni_Checked(object sender, RoutedEventArgs e)
        {
            cvs.Filter += new FilterEventHandler(Aktivni);

        }

        private void rbNeaktivni_Checked(object sender, RoutedEventArgs e)
        {
            cvs.Filter += new FilterEventHandler(Neaktivni);

        }

        private void rbSvi_Checked(object sender, RoutedEventArgs e)
        {
            cvs.Filter += new FilterEventHandler(SviJezici);

        }

        private void btnDodavanje_Click(object sender, RoutedEventArgs e)
        {
            Kurs k = new Kurs();
            KursIzmena ki = new KursIzmena(k, MOD.DODAVANJE);
            ki.ShowDialog();
        }

        private void btnIzmena_Click(object sender, RoutedEventArgs e)
        {
            Kurs k = dgKursevi.SelectedItem as Kurs;
            KursIzmena ki = new KursIzmena(k, MOD.IZMENA);
            ki.ShowDialog();

        }

        private void btnBrisanje_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Da li ste sigurni?", "Potvrda brisanja", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {

                Kurs j = dgKursevi.SelectedItem as Kurs;


                j.Status = false;

                btnBrisanje.IsEnabled = false;
                btnIzmena.IsEnabled = false;

                KursDAO.Brisanje(j);
            }
        }

        private void btnUcenici_Click(object sender, RoutedEventArgs e)
        {
            Kurs k = dgKursevi.SelectedItem as Kurs;
            PrikazUcenika pu = new PrikazUcenika(k);
            pu.ShowDialog();
        }

        private void btnNastavnici_Click(object sender, RoutedEventArgs e)
        {
            Kurs k = dgKursevi.SelectedItem as Kurs;
            PrikazNastavnika pu = new PrikazNastavnika(k);
            pu.ShowDialog();
        }


        private void SviJezici(object sender, FilterEventArgs e)
        {
            Kurs j = e.Item as Kurs;
            if (j != null)
            {
                e.Accepted = j.Status == true || j.Status == false;
            }
        }
        private void Aktivni(object sender, FilterEventArgs e)
        {
            Kurs j = e.Item as Kurs;
            if (j != null)
            {
                e.Accepted = j.Status == true;
            }
        }

        private void Neaktivni(object sender, FilterEventArgs e)
        {
            Kurs j = e.Item as Kurs;
            if (j != null)
            {
                e.Accepted = j.Status == false;
            }
        }

        private void btnUplate_Click(object sender, RoutedEventArgs e)
        {
            Kurs k = dgKursevi.SelectedItem as Kurs;
            UcProfPrikazUplata upp = new UcProfPrikazUplata(k.Uplate);
            upp.ShowDialog();

        }

        private void tbJezik_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (IsLoaded)
            {
                cvs.Filter += new FilterEventHandler(PretragaJezika);
            }
        }

        private void PretragaJezika(object sender, FilterEventArgs e)
        {
            Kurs j = e.Item as Kurs;
            if (j != null)
            {
                e.Accepted = j.Jezik.NazivJezika.ToLower().Contains(tbJezik.Text.ToLower());
            }
        }

        private void rbSortJezik_Checked(object sender, RoutedEventArgs e)
        {
           /// cvs.SortDescriptions.Add(new SortDescription(this.kurs.Jezik.ToString(), ListSortDirection.Ascending));
        }

        private void rbSortTip_Checked(object sender, RoutedEventArgs e)
        {
            //cvs.SortDescriptions.Add(new SortDescription(this.kurs.TipKursa.ToString(), ListSortDirection.Ascending));
        }

        private void tbTip_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (IsLoaded)
            {
                cvs.Filter += new FilterEventHandler(PretragaTipova);
            }
        }


        private void PretragaTipova(object sender, FilterEventArgs e)
        {
            Kurs j = e.Item as Kurs;
            if (j != null)
            {
                e.Accepted = j.TipKursa.Nivo.ToLower().Contains(tbTip.Text.ToLower());
            }
        }
    }
}
