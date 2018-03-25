using SJWPF.DAO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SJWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            KorisnikDAO.Read();
            JezikDAO.Read();
            NivoDAO.Read();
            KursDAO.Read();
            NastavnikDAO.Read();
            UcenikDAO.Read();
            NastavnikKursDAO.Read();
            UcenikKursDAO.Read();
            UplataDAO.Read();
            SkolaDAO.Read();
        }
    }
}
