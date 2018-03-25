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
    /// Interaction logic for KorisnikMeni.xaml
    /// </summary>
    public partial class KorisnikMeni : Window
    {
        public KorisnikMeni()
        {
            InitializeComponent();
        }

        private void btnUplate_Click(object sender, RoutedEventArgs e)
        {
            UplataProzor up = new UplataProzor();
            up.ShowDialog();
        }

        private void btnKursevi_Click(object sender, RoutedEventArgs e)
        {
            KursDIB kdib = new KursDIB();
            kdib.ShowDialog();
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
    }
}
