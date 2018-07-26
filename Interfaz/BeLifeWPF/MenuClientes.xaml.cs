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
    /// Lógica de interacción para MenuClientes.xaml
    /// </summary>
    public partial class MenuClientes : Page
    {
        public MenuClientes()
        {
            InitializeComponent();
        }

        private void TAgregarCliente_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AgregarCliente());
        }

        private void TListarClientes_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ListarClientes());
        }

        private void TModificarCliente_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ModificarCliente());
        }

        private void TEliminarCliente_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EliminarCliente());
        }

    }

}
