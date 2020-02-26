using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace IntranetIPScanner
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            // Specify the way to exit from the application.
            this.ShutdownMode = ShutdownMode.OnMainWindowClose;
        }
    }
}
