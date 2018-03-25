﻿using SJWPF.DAO;
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
    /// Interaction logic for NastavnikIzmena.xaml
    /// </summary>
    public partial class NastavnikIzmena : Window
    {

        protected Nastavnik original, copyObj;
        protected MOD mod;
        public NastavnikIzmena()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                original.Ime = tbIme.Text;
                original.Prezime = tbPrezime.Text;
                original.JMBG = tbJmbg.Text;
                original.Plata = Convert.ToDouble(tbPlata.Text);
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
                    int id = Aplikacija.Instanca.Nastavnici.Count + 1;
                    original.Id = id;
                    Aplikacija.Instanca.Nastavnici.Add(original);
                    NastavnikDAO.Create(original);
                }
                else
                {
                    NastavnikDAO.Update(original);
                }
                this.Close();
            }
            catch (FormatException)
            {

                MessageBox.Show("Plata mora biti broj");

            }









        }

        private void btnOtkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public NastavnikIzmena(Nastavnik j, MOD m = MOD.DODAVANJE):this()
        {
            this.original = j;
            this.copyObj = (Nastavnik)original.Clone();
            this.mod = m;
            this.DataContext = copyObj;


        }
    }
}
