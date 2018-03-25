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
    /// Interaction logic for UplataProzor.xaml
    /// </summary>
    public partial class UplataProzor : Window
    {
        private CollectionViewSource cvs;
        public UplataProzor()
        {
            InitializeComponent();
            cvs = new CollectionViewSource();
            cvs.Source = Aplikacija.Instanca.Uplate;
            dgUplata.ItemsSource = cvs.View;
            dgUplata.IsReadOnly = true;
            dgUplata.SelectionMode = DataGridSelectionMode.Single;
            dgUplata.AutoGenerateColumns = true;
        }

        private void btnUplati_Click(object sender, RoutedEventArgs e)
        {
            Uplata u = dgUplata.SelectedItem as Uplata;
            u.StatusUplate = true;
            UplataDAO.Uplati(u);
        }

        private void rbNeplaceno_Checked(object sender, RoutedEventArgs e)
        {
            cvs.Filter += new FilterEventHandler(Neaktivni);
        }

        private void rbPlaceno_Checked(object sender, RoutedEventArgs e)
        {
            cvs.Filter += new FilterEventHandler(Aktivni);
        }


        private void Aktivni(object sender, FilterEventArgs e)
        {
            Uplata j = e.Item as Uplata;
            if (j != null)
            {
                e.Accepted = j.StatusUplate == true;
            }
        }

        private void Neaktivni(object sender, FilterEventArgs e)
        {
            Uplata j = e.Item as Uplata;
            if (j != null)
            {
                e.Accepted = j.StatusUplate == false;
            }
        }

        private void btnIzbrisi_Click(object sender, RoutedEventArgs e)
        {
            Uplata u = dgUplata.SelectedItem as Uplata;
            
            u.Kurs.Uplate.Remove(u);
            u.Ucenik.Uplate.Remove(u);
            Aplikacija.Instanca.Uplate.Remove(u);
            UplataDAO.Delete(u);

        }

        private void tbUcenik_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (IsLoaded)
            {
                cvs.Filter += new FilterEventHandler(PretragaUcenik);
            }
        }

        private void tbKurs_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (IsLoaded)
            {
                cvs.Filter += new FilterEventHandler(PretragaKurs);
            }
        }

        private void PretragaKurs(object sender, FilterEventArgs e)
        {
            Uplata j = e.Item as Uplata;
            if (j != null)
            {
                e.Accepted = j.Kurs.ToString().ToLower().Contains(tbKurs.Text.ToLower());
            }
        }

        private void PretragaUcenik(object sender, FilterEventArgs e)
        {
            Uplata j = e.Item as Uplata;
            if (j != null)
            {
                e.Accepted = j.Ucenik.Ime.Contains(tbUcenik.Text.ToLower());
            }
        }
    }
}
