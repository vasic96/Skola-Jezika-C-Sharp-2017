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
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        public LogIn()
        {
            InitializeComponent();

        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            Korisnik korisnik = Aplikacija.Instanca.login(tbUsername.Text, pbLozinka.Password);
            if (korisnik == null || korisnik.Status == false)
                MessageBox.Show("Pokusajte ponovo", "Pogresno korisnicko ime/lozinka!");
            else if (korisnik.Uloga == true)
            {
                Admin admn = new Admin();
                admn.Show();
                this.Close();
            }

            else 
            {
                KorisnikMeni kmeni = new KorisnikMeni();
                kmeni.Show();
                this.Close();
            }



        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            Info i = new Info();
            i.ShowDialog();
        }
    }
}
