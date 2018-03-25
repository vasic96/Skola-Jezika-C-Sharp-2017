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
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void btnOdjava_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Da li ste sigurni?", "Odjava", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                LogIn lw = new LogIn();
                lw.Show();
                this.Close();
            }


        }

        private void btnOdjava_Click_1(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Da li ste sigurni?", "Odjava", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                LogIn lw = new LogIn();
                lw.Show();
                this.Close();
            }

        }

        private void btnJezici_Click(object sender, RoutedEventArgs e)
        {
            JezikDIB jdib = new JezikDIB();
            jdib.ShowDialog();
        }

        private void btnTipovi_Click(object sender, RoutedEventArgs e)
        {
            NivoiDIB ndib = new NivoiDIB();
            ndib.ShowDialog();
        }

        private void btnSkola_Click(object sender, RoutedEventArgs e)
        {
            //Skola skola = Aplikacija.Instanca.Skola;
            SkolaPrikaz sp = new SkolaPrikaz(Aplikacija.Instanca.Skola);
            sp.ShowDialog();

        }

        private void btnKorisnici_Click(object sender, RoutedEventArgs e)
        {
            KorisniciDIB kdib = new KorisniciDIB();
            kdib.ShowDialog();
        }

        private void btnUcenici_Click(object sender, RoutedEventArgs e)
        {
            UceniciDIB udib = new UceniciDIB();
            udib.ShowDialog();
        }

        private void btnNastavnici_Click(object sender, RoutedEventArgs e)
        {
            NastavniciDIB ndib = new NastavniciDIB();
            ndib.ShowDialog();
        }
    }
}
