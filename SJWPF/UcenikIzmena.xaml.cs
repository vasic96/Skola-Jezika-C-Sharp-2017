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
    /// Interaction logic for UcenikIzmena.xaml
    /// </summary>
    public partial class UcenikIzmena : Window
    {

        protected Ucenik original, copyObj;
        protected MOD mod;
        public UcenikIzmena()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            original.Ime = tbIme.Text;
            original.Prezime = tbPrezime.Text;
            original.JMBG = tbJmbg.Text;
            original.Email = tbEmail.Text;
            original.Adresa = tbAdresa.Text;
            original.BrTelefona = tbBrojTelefona.Text;
            if (cbStatus.IsChecked == true)
            {
                original.Status = true;
            }
            else
            {
                original.Status = false;
            }
            if (mod == MOD.DODAVANJE)
            {
                int id = Aplikacija.Instanca.Ucenici.Count + 1;
                original.Id = id;
                Aplikacija.Instanca.Ucenici.Add(original);
                UcenikDAO.Create(original);
            }

            else
            {
                UcenikDAO.Update(original);
            }
            this.Close();
        }

        private void btnOtkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public UcenikIzmena(Ucenik j, MOD m = MOD.DODAVANJE):this()
        {
            this.original = j;
            this.copyObj = (Ucenik)original.Clone();
            this.mod = m;
            this.DataContext = copyObj;


        }



    }
}
