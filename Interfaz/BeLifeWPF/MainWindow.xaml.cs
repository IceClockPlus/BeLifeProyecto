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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace BeLifeWPF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {

        private bool AltoContraste { get; set; }
        private bool SideBarActivo { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void BtnMenuPrincipal_Click(object sender, RoutedEventArgs e)
        {
            FrmVentana.NavigationService.Navigate(new MenuPrincipal());
        }

        private void BtbMenuClientes_Click(object sender, RoutedEventArgs e)
        {
            FrmVentana.NavigationService.Navigate(new MenuClientes());
        }

        private void BtnMenuContratos_Click(object sender, RoutedEventArgs e)
        {
            FrmVentana.NavigationService.Navigate(new MenuContratos());
        }

        private void BtnSideMenu_Click(object sender, RoutedEventArgs e)
        {
            if (!SideBarActivo)
            {
                Storyboard sb = Resources["sbSideMenuBarMostrar"] as Storyboard;
                sb.Begin(SideBarMenu);
                SideBarActivo = true;
            }
            else
            {
                Storyboard sb = Resources["sbSideMenuBarOcultar"] as Storyboard;
                sb.Begin(SideBarMenu);
                SideBarActivo = false;
            }
        }

        private void BtnContraste_Click(object sender, RoutedEventArgs e)
        {
            if (!AltoContraste)
            {
                Tuple<AppTheme, Accent> appStyle = ThemeManager.DetectAppStyle(Application.Current);

                // now set the Green accent and dark theme
                ThemeManager.ChangeAppStyle(Application.Current,
                                            ThemeManager.GetAccent("Green"),
                                            ThemeManager.GetAppTheme("BaseDark"));
                AltoContraste = true;
            }
            else
            {
                Tuple<AppTheme, Accent> appStyle = ThemeManager.DetectAppStyle(Application.Current);

                // now set the Green accent and dark theme
                ThemeManager.ChangeAppStyle(Application.Current,
                                            ThemeManager.GetAccent("Violet"),
                                            ThemeManager.GetAppTheme("BaseLight"));
                AltoContraste = false;

            }
        }


      


    }
}
