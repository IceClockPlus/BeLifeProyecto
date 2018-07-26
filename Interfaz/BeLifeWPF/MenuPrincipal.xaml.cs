using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Lógica de interacción para MenuPrincipal.xaml
    /// </summary>
    public partial class MenuPrincipal : Page
    {
        public string NombreMes(int mes)
        {
            DateTimeFormatInfo dtinfo = new CultureInfo("es-ES", false).DateTimeFormat;
            return dtinfo.GetMonthName(mes).ToUpper();
        }

        public MenuPrincipal()
        {
            InitializeComponent();
            this.MostrarFecha();
        }

        public void MostrarFecha()
        {
            TDia.Text = DateTime.Today.Day.ToString();
            TMes.Text = NombreMes(DateTime.Today.Month);
        }

        private void BtnListarClientes_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ListarClientes());
        }

        private void BtnListarContratos_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ListarContratos());
        }
    }
}
