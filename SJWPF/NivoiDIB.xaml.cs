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
    /// Interaction logic for NivoiDIB.xaml
    /// </summary>
    public partial class NivoiDIB : Window
    {
        private CollectionViewSource cvs;
        public NivoiDIB()
        {
            InitializeComponent();
            
            btnIzmena.IsEnabled = false;
            btnBrisanje.IsEnabled = false;
            cvs = new CollectionViewSource();
            cvs.Source = Aplikacija.Instanca.Tipovi;
            dgNivoi.ItemsSource = cvs.View;
            dgNivoi.IsReadOnly = true;
            dgNivoi.SelectionMode = DataGridSelectionMode.Single;
        }

        private void dgNivoi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (IsLoaded)
            {
                btnIzmena.IsEnabled = true;
                btnBrisanje.IsEnabled = true;

            }
        }

        private void tbNaziv_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (IsLoaded)
            {
                cvs.Filter += new FilterEventHandler(PretragaNaziva);
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

        private void rbSvi_Checked(object sender, RoutedEventArgs e)
        {
            if (IsLoaded)
            {
                cvs.Filter += new FilterEventHandler(SviJezici);
            }
        }

        private void btnDodavanje_Click(object sender, RoutedEventArgs e)
        {
            TipKursa t = new TipKursa("", "", true);
            NivoiIzmena nizm = new NivoiIzmena(t, MOD.DODAVANJE);
            nizm.ShowDialog();

        }

        private void btnIzmena_Click(object sender, RoutedEventArgs e)
        {

            TipKursa t = dgNivoi.SelectedItem as TipKursa;
            NivoiIzmena nizm = new NivoiIzmena(t, MOD.IZMENA);
            nizm.ShowDialog();

        }

        private void btnBrisanje_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Da li ste sigurni?", "Potvrda brisanja", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {

                TipKursa j = dgNivoi.SelectedItem as TipKursa;


                j.Status = false;

                btnBrisanje.IsEnabled = false;
                btnIzmena.IsEnabled = false;

                NivoDAO.Brisanje(j);
            }

        }

        private void PretragaNaziva(object sender, FilterEventArgs e)
        {
            TipKursa j = e.Item as TipKursa;
            if (j != null)
            {
                e.Accepted = j.Nivo.ToLower().Contains(tbNaziv.Text.ToLower());
            }
        }

        private void SviJezici(object sender, FilterEventArgs e)
        {
            TipKursa j = e.Item as TipKursa;
            if (j != null)
            {
                e.Accepted = j.Status == true || j.Status == false;
            }
        }
        private void Aktivni(object sender, FilterEventArgs e)
        {
            TipKursa j = e.Item as TipKursa;
            if (j != null)
            {
                e.Accepted = j.Status == true;
            }
        }

        private void Neaktivni(object sender, FilterEventArgs e)
        {
            TipKursa j = e.Item as TipKursa;
            if (j != null)
            {
                e.Accepted = j.Status == false;
            }
        }
    }
}
