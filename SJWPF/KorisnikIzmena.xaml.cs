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
    /// Interaction logic for KorisnikIzmena.xaml
    /// </summary>
    public partial class KorisnikIzmena : Window
    {
        protected Korisnik original, copyObj;
        protected MOD mod;
        public KorisnikIzmena()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            original.Ime = tbIme.Text;
            original.Prezime = tbPrezime.Text;
            original.JMBG = tbJMBG.Text;
            original.KorisnickoIme = tbKime.Text;
            original.Lozinka = tbLozinka.Text;

            if (cbStatus.IsChecked == true)
            {
                original.Status = true;
            }
            else
            {
                original.Status = false;
            }

            if (cbAdmin.IsChecked == true)
            {
                original.Uloga = true;
            }
            else
            {
                original.Uloga = false;
            }

            if (mod == MOD.DODAVANJE)
            {
                int id = Aplikacija.Instanca.Korisnici.Count + 1;
                original.Id = id;
                Aplikacija.Instanca.Korisnici.Add(original);
                KorisnikDAO.Create(original);
            }
            else
            {
                KorisnikDAO.Update(original);
            }
            this.Close();

        }

        private void btnOtkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public KorisnikIzmena(Korisnik k, MOD m = MOD.DODAVANJE) : this()
        {

            if(m == MOD.IZMENA)
            {
                tbJMBG.IsEnabled = false;
            }
            this.original = k;
            this.copyObj = (Korisnik)original.Clone();
            this.mod = m;
            this.DataContext = copyObj;


        }
    }
}
