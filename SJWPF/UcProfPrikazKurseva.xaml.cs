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
    /// Interaction logic for UcProfPrikazKurseva.xaml
    /// </summary>
    public partial class UcProfPrikazKurseva : Window
    {
        protected Ucenik original, copyObj;
        private CollectionViewSource cvs;
        public UcProfPrikazKurseva()
        {
  



        }

        ObservableCollection<Kurs> Kursevi = new ObservableCollection<Kurs>();

        public UcProfPrikazKurseva(ObservableCollection<Kurs> Kursevi) : this()
        {

            InitializeComponent();
            Jezik j;

            cvs = new CollectionViewSource();
            cvs.Source = Kursevi;
            dgKursevi.ItemsSource = cvs.View;
            dgKursevi.IsReadOnly = true;
            dgKursevi.SelectionMode = DataGridSelectionMode.Single;
            dgKursevi.AutoGenerateColumns = false;

            DataGridTextColumn naziv = new DataGridTextColumn();
            naziv.Header = "Naziv Jezika";
           naziv.Binding = new Binding("Jezik");


            DataGridTextColumn tip = new DataGridTextColumn();
            tip.Header = "Nivo Jezika";
            tip.Binding = new Binding("TipKursa");


            DataGridTextColumn cena = new DataGridTextColumn();
            cena.Header = "Cena";
            cena.Binding = new Binding("Cena");


            dgKursevi.Columns.Add(naziv);
            dgKursevi.Columns.Add(tip);
            dgKursevi.Columns.Add(cena);
        }
    }
}
