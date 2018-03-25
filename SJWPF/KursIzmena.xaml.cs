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
    /// Interaction logic for KursIzmena.xaml
    /// </summary>
    public partial class KursIzmena : Window
    {
        protected Kurs original, copyObj;
        protected MOD mod;
        public KursIzmena()
        {
            InitializeComponent();

            foreach (Jezik j in Aplikacija.Instanca.Jezici)
            {
                if(j.Status == true)
                {
                    cbJezik.Items.Add(j);
                }
            }
            foreach (TipKursa t in Aplikacija.Instanca.Tipovi)
            {
                if(t.Status == true)
                {
                    cbTip.Items.Add(t);
                }
            }
            if (mod == MOD.DODAVANJE)
            {
                dpDatumPocetak.SelectedDate = DateTime.Now;
                dpDatumKraj.SelectedDate = DateTime.Now;
            }



        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            try
            {

                original.Jezik = cbJezik.SelectedItem as Jezik;
                original.TipKursa = cbTip.SelectedItem as TipKursa;
                original.Cena = Convert.ToDouble(tbCena.Text);
                original.DatumPocetak = dpDatumPocetak.SelectedDate.Value;
                original.DatumKraj = dpDatumKraj.SelectedDate.Value;
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
                    int id = Aplikacija.Instanca.Kursevi.Count + 1;
                    original.Id = id;
                    Aplikacija.Instanca.Kursevi.Add(original);
                    KursDAO.Create(original);
                }
                else
                {
                    KursDAO.Update(original);
                }

                this.Close();

            }
            catch (FormatException)
            {

                MessageBox.Show("Plata mora biti broj");
            }
   
        }

        public KursIzmena(Kurs k, MOD m = MOD.DODAVANJE):this()
        {

            if (mod == MOD.DODAVANJE)
            {
                dpDatumPocetak.Text = DateTime.Now.Date.ToString();
               // dpDatumKraj.SelectedDate.Value = DateTime.Today;
            }
            this.original = k;
            this.copyObj = (Kurs)original.Clone();
            this.mod = m;
            this.DataContext = copyObj;

            if (mod == MOD.IZMENA)
            {
                cbJezik.IsEnabled = false;
                cbTip.IsEnabled = false;
            }

            if (mod == MOD.DODAVANJE)
            {
                dpDatumPocetak.SelectedDate = DateTime.Now;
                dpDatumKraj.SelectedDate = DateTime.Now;
            }




        }
    }
}
