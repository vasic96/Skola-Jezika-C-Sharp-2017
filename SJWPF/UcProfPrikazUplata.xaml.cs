using SJWPF.Klase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for UcProfPrikazUplata.xaml
    /// </summary>
    public partial class UcProfPrikazUplata : Window
    {
        protected Ucenik original, copyObj;
        private CollectionViewSource cvs;
        public UcProfPrikazUplata()
        {
          
        }


        ObservableCollection<Uplata> Uplate = new ObservableCollection<Uplata>();
        public UcProfPrikazUplata(ObservableCollection<Uplata> Uplate)
        {
            InitializeComponent();
            cvs = new CollectionViewSource();
            cvs.Source = Uplate;
            dgUplate.ItemsSource = cvs.View;
            dgUplate.IsReadOnly = true;
            dgUplate.SelectionMode = DataGridSelectionMode.Single;
            //dgUplate.AutoGenerateColumns = false;




            //DataGridTextColumn kurs = new DataGridTextColumn();
            //kurs.Header = "Naziv Jezika";
            //kurs.Binding = new Binding("Kurs");


            //DataGridTextColumn tip = new DataGridTextColumn();
            //tip.Header = "Nivo Jezika";
            //tip.Binding = new Binding("TipKursa");


            //DataGridTextColumn cena = new DataGridTextColumn();
            //cena.Header = "Cena";
            //cena.Binding = new Binding("Cena");


            //dgKursevi.Columns.Add(naziv);
            //dgKursevi.Columns.Add(tip);
            //dgKursevi.Columns.Add(cena);
        }
    }
}
