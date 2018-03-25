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
    /// Interaction logic for NivoiIzmena.xaml
    /// </summary>
    public partial class NivoiIzmena : Window
    {

        protected TipKursa original, copyObj;
        protected MOD mod;
        public NivoiIzmena()
        {
            InitializeComponent();
        }

        public NivoiIzmena(TipKursa j, MOD m = MOD.DODAVANJE) : this()
        {
            this.original = j;
            this.copyObj = (TipKursa)original.Clone();
            this.mod = m;
            this.DataContext = copyObj;


        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            original.Nivo = tbNivo.Text;
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
                int id = Aplikacija.Instanca.Tipovi.Count + 1;
                original.Id = id;
                Aplikacija.Instanca.Tipovi.Add(original);
                NivoDAO.Create(original);

            }
            else
            {
                NivoDAO.Update(original);
            }

            this.Close();

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
