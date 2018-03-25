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
    /// Interaction logic for Jezici.xaml
    /// </summary>
    public partial class Jezici : Window
    {
        private CollectionViewSource cvs;
        public Jezici()
        {
 
            InitializeComponent();

            
                btnIzmeni.IsEnabled = false;
                btnObrisi.IsEnabled = false;
            
            cvs = new CollectionViewSource();
            cvs.Source = Aplikacija.Instanca.Jezici;
            dgJezici.ItemsSource = cvs.View;
            dgJezici.IsReadOnly = true;
            dgJezici.SelectionMode = DataGridSelectionMode.Single;

        }

        private void dgJezici_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Jezik j = dgJezici.SelectedItem as Jezik;
            if (IsLoaded)
            {
               
               // btnIzmeni.IsEnabled = true;
                //if (j.Status == true)
                //{
                    btnObrisi.IsEnabled = true;
                //}
            }

           
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            Jezik j = dgJezici.SelectedItem as Jezik;
            j.Status = false;

        }
    }
}
