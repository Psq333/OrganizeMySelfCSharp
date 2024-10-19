using OrganizeMySelf.ViewModels;
using OrganizeMySelf.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace OrganizeMySelf
{
    /// <summary>
    /// Logica di interazione per App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            this.MainWindow = new MainWindowView();
            this.MainWindow.DataContext = new MainWindowViewModel();
            //Con la riga di sopra divido il ponte di comunicazioe tra la view e il model
            this.MainWindow.Show();
        }
    }
}
