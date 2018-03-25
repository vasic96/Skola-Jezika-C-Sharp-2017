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
    /// Interaction logic for JezikIzmena.xaml
    /// </summary>
    public partial class JezikIzmena : Window
    {
        protected Jezik original, copyObj;
        protected MOD mod;
        public JezikIzmena()
        {
            InitializeComponent();

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            original.NazivJezika = tbNaziv.Text;
            original.Oznaka = tbOznaka.Text;

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
                int id = Aplikacija.Instanca.Jezici.Count + 1;
                original.Id = id;
                Aplikacija.Instanca.Jezici.Add(original);
                JezikDAO.Create(original);
            }
            else
            {
  
                JezikDAO.Update(original);
            }

            this.Close();

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public JezikIzmena(Jezik j, MOD m = MOD.DODAVANJE) : this()
        {
            this.original = j;
            this.copyObj = (Jezik)original.Clone();
            this.mod = m;
            this.DataContext = copyObj;


        }
    }
}
