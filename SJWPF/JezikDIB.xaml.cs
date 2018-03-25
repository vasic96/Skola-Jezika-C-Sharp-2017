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
    /// Interaction logic for JezikDIB.xaml
    /// </summary>
    /// 

    public enum MOD { DODAVANJE, IZMENA };
    public partial class JezikDIB : Window
    {
        private bool prazno = false;

        private CollectionViewSource cvs;
        public JezikDIB()
        {
            InitializeComponent();
            btnIzmena.IsEnabled = false;
            btnBrisanje.IsEnabled = false;
            cvs = new CollectionViewSource();
            cvs.Source = Aplikacija.Instanca.Jezici;
            dgJezici.ItemsSource = cvs.View;
            dgJezici.IsReadOnly = true;
            dgJezici.SelectionMode = DataGridSelectionMode.Single;

            


        }

        private void dgJezici_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          //  if (IsLoaded)
         //   {
  
                if (IsLoaded)
                {
                    btnIzmena.IsEnabled = true;
                    btnBrisanje.IsEnabled = true;
                }
                
           // }
        }

        private void btnBrisanje_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Da li ste sigurni?", "Potvrda brisanja", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                
                Jezik j = dgJezici.SelectedItem as Jezik;

                
                    j.Status = false;

                btnBrisanje.IsEnabled = false;
                btnIzmena.IsEnabled = false;

                JezikDAO.Brisanje(j);
            }
        }

        private void btnIzmena_Click(object sender, RoutedEventArgs e)
        {
            Jezik j = dgJezici.SelectedItem as Jezik;
            JezikIzmena ji = new JezikIzmena(j, MOD.IZMENA);
            ji.ShowDialog();
        }

        private void btnDodavanje_Click(object sender, RoutedEventArgs e)
        {
            Jezik j = new Jezik("","",true);
            JezikIzmena ji = new JezikIzmena(j, MOD.DODAVANJE);
            ji.ShowDialog();
        }

        private void PretragaOznaka(object sender, FilterEventArgs e)
        {
            Jezik j = e.Item as Jezik;
            if (j != null)
            {
                e.Accepted = j.Oznaka.ToLower().Contains(tbOznaka.Text.ToLower());
            }
        }

        private void tbOznaka_TextChanged(object sender, TextChangedEventArgs e)

        {
            if (IsLoaded)
            {
                cvs.Filter += new FilterEventHandler(PretragaOznaka);
            }
        }

        private void rbSvi_Checked(object sender, RoutedEventArgs e)
        {
            if (IsLoaded)
            {
                cvs.Filter += new FilterEventHandler(SviJezici);
            }
        }

        private void rbIzbrisani_Checked(object sender, RoutedEventArgs e)
        {
            cvs.Filter += new FilterEventHandler(Neaktivni); 
        }

        private void rbAktivni_Checked(object sender, RoutedEventArgs e)
        {
            cvs.Filter += new FilterEventHandler(Aktivni);

        }

        private void SviJezici(object sender, FilterEventArgs e)
        {
            Jezik j = e.Item as Jezik;
            if (j != null)
            {
                e.Accepted = j.Status == true || j.Status == false;
            }
        }
        private void Aktivni(object sender, FilterEventArgs e)
        {
            Jezik j = e.Item as Jezik;
            if (j != null)
            {
                e.Accepted = j.Status == true;
            }
        }

        private void Neaktivni(object sender, FilterEventArgs e)
        {
            Jezik j = e.Item as Jezik;
            if (j != null)
            {
                e.Accepted = j.Status == false;
            }
        }
    }
}
