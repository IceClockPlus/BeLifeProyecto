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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BeLifeWPF
{
    /// <summary>
    /// Lógica de interacción para MenuContratos.xaml
    /// </summary>
    public partial class MenuContratos : Page
    {
        public MenuContratos()
        {
            InitializeComponent();


        }

        private void TAgregarContrato_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AgregarContrato());
        }

        private void TModificarContrato_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ModificarContrato());
        }

        private void TListarContratos_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ListarContratos());
        }


    }

}
