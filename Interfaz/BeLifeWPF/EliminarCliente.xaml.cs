using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
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
    /// Lógica de interacción para EliminarCliente.xaml
    /// </summary>
    public partial class EliminarCliente : Page
    {
        public EliminarCliente()
        {
            InitializeComponent();
            this.CargarEstadoCivil();
            this.CargarSexo();
        }


        private void CargarEstadoCivil()
        {
            BelifeLibrary.EstadoCivil est = new BelifeLibrary.EstadoCivil();
            List<BelifeLibrary.EstadoCivil> lista = new List<BelifeLibrary.EstadoCivil>();
            List<string> listadesc = new List<string>();
            lista = est.ReadAll();
            foreach (var x in lista)
            {
                listadesc.Add(x.Descripcion);
            }

            ComboEstCivilBuscar.ItemsSource = listadesc;
            ComboEstCivilBuscar.Items.Refresh();

            
        }

        private void CargarTodosClientes()
        {
            BelifeLibrary.Cliente cl = new BelifeLibrary.Cliente();
            DtgClientes.ItemsSource = cl.ReadAll();
        }

        private void CargarSexo()
        {

            BelifeLibrary.Sexo sexo = new BelifeLibrary.Sexo();
            List<BelifeLibrary.Sexo> lista = new List<BelifeLibrary.Sexo>();
            List<string> listadesc = new List<string>();
            lista = sexo.ReadAll();
            foreach (var x in lista)
            {
                listadesc.Add(x.Descripcion);
            }

            ComboSexoBuscar.ItemsSource = listadesc;
            ComboSexoBuscar.Items.Refresh();

            
        }

        private void BtnBuscarCliente_Click(object sender, RoutedEventArgs e)
        {
            FlyBuscarCliente.IsOpen = true;
            this.CargarTodosClientes();
        }

        private async void BtnEliminarCliente_Click(object sender, RoutedEventArgs e)
        {
            var metroWindow = (Application.Current.MainWindow as MetroWindow);

            try
            {
                BelifeLibrary.Cliente cli = new BelifeLibrary.Cliente();
                cli.Rut = TxtRut.Text;
                if (cli.Delete())
                {
                    await metroWindow.ShowMessageAsync("Eliminar Cliente", "El Cliente fue eliminado exitosamente");
                }
                else
                {
                    await metroWindow.ShowMessageAsync("Eliminar Cliente", "Error al eliminar cliente");
                }
            }
            catch (Exception er)
            {

                await metroWindow.ShowMessageAsync("Error!! ", er.Message);
            }

        }

        private void BtnFiltrar_Click(object sender, RoutedEventArgs e)
        {
            List<BelifeLibrary.Cliente> Clientes = new List<BelifeLibrary.Cliente>();

            try
            {

                //Solo Filtro por Rut
                if (!TxtRutBuscar.Text.Equals(String.Empty) && ComboEstCivilBuscar.SelectedIndex == -1 && ComboSexoBuscar.SelectedIndex == -1)                {                    BelifeLibrary.Cliente cliRut = new BelifeLibrary.Cliente();                    cliRut.Rut = TxtRutBuscar.Text;                    Clientes.Add(cliRut.Read());                    DtgClientes.ItemsSource = Clientes;
                    //Filtro por Estado Civil y Rut
                }
                else if (!TxtRutBuscar.Text.Equals(String.Empty) && ComboEstCivilBuscar.SelectedIndex != -1 && ComboSexoBuscar.SelectedIndex == -1)
                {
                    BelifeLibrary.Cliente cliRutEstCivil = new BelifeLibrary.Cliente();
                    cliRutEstCivil.IdEstadoCivil = ComboEstCivilBuscar.SelectedIndex + 1;
                    Clientes = cliRutEstCivil.ReadAllByEstadoCivil();
                    Clientes = Clientes.Where(x => x.Rut.Equals(TxtRutBuscar.Text)).ToList();
                    DtgClientes.ItemsSource = Clientes;

                    //Filtro Rut y Sexo
                }
                else if (!TxtRutBuscar.Text.Equals(String.Empty) && ComboEstCivilBuscar.SelectedIndex == -1 && ComboSexoBuscar.SelectedIndex != -1)
                {
                    BelifeLibrary.Cliente cliRutSexo = new BelifeLibrary.Cliente();
                    cliRutSexo.IdSexo = ComboSexoBuscar.SelectedIndex + 1;
                    Clientes = cliRutSexo.ReadAllBySexo();
                    Clientes = Clientes.Where(x => x.Rut.Equals(TxtRutBuscar.Text)).ToList();
                    DtgClientes.ItemsSource = Clientes;

                    //Filtro Estaoo Civil y Sexo
                }
                else if (String.IsNullOrEmpty(TxtRutBuscar.Text) && ComboEstCivilBuscar.SelectedIndex != -1 && ComboSexoBuscar.SelectedIndex != -1)
                {
                    BelifeLibrary.Cliente cliCivilSexo = new BelifeLibrary.Cliente();
                    cliCivilSexo.IdEstadoCivil = ComboEstCivilBuscar.SelectedIndex + 1;
                    Clientes = cliCivilSexo.ReadAllByEstadoCivil();
                    Clientes = Clientes.Where(x => x.IdSexo == ComboSexoBuscar.SelectedIndex + 1).ToList();
                    DtgClientes.ItemsSource = Clientes;

                    //Filtro Solo Estado Civil
                }
                else if (String.IsNullOrEmpty(TxtRutBuscar.Text) && ComboEstCivilBuscar.SelectedIndex != -1 && ComboSexoBuscar.SelectedIndex == -1)
                {
                    BelifeLibrary.Cliente cliEst = new BelifeLibrary.Cliente();
                    cliEst.IdEstadoCivil = ComboEstCivilBuscar.SelectedIndex + 1;
                    DtgClientes.ItemsSource = cliEst.ReadAllByEstadoCivil();

                    //Filtro Solo Sexo
                }
                else if (String.IsNullOrEmpty(TxtRutBuscar.Text) && ComboEstCivilBuscar.SelectedIndex == -1 && ComboSexoBuscar.SelectedIndex != -1)
                {
                    BelifeLibrary.Cliente cliSexo = new BelifeLibrary.Cliente();
                    cliSexo.IdSexo = ComboSexoBuscar.SelectedIndex + 1;
                    DtgClientes.ItemsSource = cliSexo.ReadAllBySexo();

                    //Filtro Sexo, Estado Civil y Rut
                }
                else if (!String.IsNullOrEmpty(TxtRutBuscar.Text) && ComboEstCivilBuscar.SelectedIndex != -1 && ComboSexoBuscar.SelectedIndex != -1)
                {
                    BelifeLibrary.Cliente cliFiltroTotal = new BelifeLibrary.Cliente();
                    cliFiltroTotal.IdEstadoCivil = ComboEstCivilBuscar.SelectedIndex + 1;
                    Clientes = cliFiltroTotal.ReadAllByEstadoCivil();
                    Clientes = Clientes.Where(x => x.IdSexo == ComboSexoBuscar.SelectedIndex + 1 && x.Rut == TxtRutBuscar.Text).ToList();
                    DtgClientes.ItemsSource = Clientes;
                }




                //
                if (String.IsNullOrEmpty(TxtRutBuscar.Text) && ComboEstCivilBuscar.SelectedIndex == -1 && ComboSexoBuscar.SelectedIndex == -1)
                {
                    this.CargarTodosClientes();
                }

                TxtRutBuscar.Text = string.Empty;
                ComboEstCivilBuscar.SelectedIndex = -1;
                ComboSexoBuscar.SelectedIndex = -1;

            }
            catch (Exception ex)
            {

            }
        }

        private void BtnSeleccionar_Click(object sender, RoutedEventArgs e)
        {
            DataGrid dataGrid = DtgClientes;
            DataGridRow Row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);
            DataGridCell RowAndColumn = (DataGridCell)dataGrid.Columns[1].GetCellContent(Row).Parent;
            string CellValue = ((TextBlock)RowAndColumn.Content).Text;

            BelifeLibrary.Cliente cliencontrado = new BelifeLibrary.Cliente();
            cliencontrado.Rut = CellValue;
            cliencontrado.Read();

            TxtRut.Text = cliencontrado.Rut;
            

            FlyBuscarCliente.IsOpen = false;
        }

    }

}
