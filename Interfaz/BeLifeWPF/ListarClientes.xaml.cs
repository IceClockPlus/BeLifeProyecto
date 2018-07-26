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
    /// Lógica de interacción para ListarClientes.xaml
    /// </summary>
    public partial class ListarClientes : Page
    {
        public ListarClientes()
        {
            InitializeComponent();
            this.CargarTodosClientes();
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

            ComboEstCivilFiltro.ItemsSource = listadesc;
            ComboEstCivilFiltro.Items.Refresh();
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

            ComboSexoFiltro.ItemsSource = listadesc;
            ComboSexoFiltro.Items.Refresh();
        }


        private void CargarTodosClientes()
        {
            BelifeLibrary.Cliente cli = new BelifeLibrary.Cliente();
            DtgClientes.ItemsSource = cli.ReadAll();
        }

       

        private void BtnFiltrar_Click(object sender, RoutedEventArgs e)
        {

            List<BelifeLibrary.Cliente> Clientes = new List<BelifeLibrary.Cliente>();

            try
            {

                //Solo Filtro por Rut
                if (!TxtRutFiltro.Text.Equals(String.Empty) && ComboEstCivilFiltro.SelectedIndex == -1 && ComboSexoFiltro.SelectedIndex == -1)                {                    BelifeLibrary.Cliente cliRut = new BelifeLibrary.Cliente();                    cliRut.Rut = TxtRutFiltro.Text;                    Clientes.Add(cliRut.Read());                    DtgClientes.ItemsSource = Clientes;
                    //Filtro por Estado Civil y Rut
                }
                else if (!TxtRutFiltro.Text.Equals(String.Empty) && ComboEstCivilFiltro.SelectedIndex != -1 && ComboSexoFiltro.SelectedIndex == -1)
                {
                    BelifeLibrary.Cliente cliRutEstCivil = new BelifeLibrary.Cliente();
                    cliRutEstCivil.IdEstadoCivil = ComboEstCivilFiltro.SelectedIndex + 1;
                    Clientes = cliRutEstCivil.ReadAllByEstadoCivil();
                    Clientes = Clientes.Where(x => x.Rut.Equals(TxtRutFiltro.Text)).ToList();
                    DtgClientes.ItemsSource = Clientes;

                    //Filtro Rut y Sexo
                }
                else if (!TxtRutFiltro.Text.Equals(String.Empty) && ComboEstCivilFiltro.SelectedIndex == -1 && ComboSexoFiltro.SelectedIndex != -1)
                {
                    BelifeLibrary.Cliente cliRutSexo = new BelifeLibrary.Cliente();
                    cliRutSexo.IdSexo = ComboSexoFiltro.SelectedIndex + 1;
                    Clientes = cliRutSexo.ReadAllBySexo();
                    Clientes = Clientes.Where(x => x.Rut.Equals(TxtRutFiltro.Text)).ToList();
                    DtgClientes.ItemsSource = Clientes;

                    //Filtro Estaoo Civil y Sexo
                }
                else if (String.IsNullOrEmpty(TxtRutFiltro.Text) && ComboEstCivilFiltro.SelectedIndex != -1 && ComboSexoFiltro.SelectedIndex != -1)
                {
                    BelifeLibrary.Cliente cliCivilSexo = new BelifeLibrary.Cliente();
                    cliCivilSexo.IdEstadoCivil = ComboEstCivilFiltro.SelectedIndex + 1;
                    Clientes = cliCivilSexo.ReadAllByEstadoCivil();
                    Clientes = Clientes.Where(x => x.IdSexo == ComboSexoFiltro.SelectedIndex + 1).ToList();
                    DtgClientes.ItemsSource = Clientes;

                    //Filtro Solo Estado Civil
                }
                else if (String.IsNullOrEmpty(TxtRutFiltro.Text) && ComboEstCivilFiltro.SelectedIndex != -1 && ComboSexoFiltro.SelectedIndex == -1)
                {
                    BelifeLibrary.Cliente cliEst = new BelifeLibrary.Cliente();
                    cliEst.IdEstadoCivil = ComboEstCivilFiltro.SelectedIndex + 1;
                    DtgClientes.ItemsSource = cliEst.ReadAllByEstadoCivil();

                    //Filtro Solo Sexo
                }
                else if (String.IsNullOrEmpty(TxtRutFiltro.Text) && ComboEstCivilFiltro.SelectedIndex == -1 && ComboSexoFiltro.SelectedIndex != -1)
                {
                    BelifeLibrary.Cliente cliSexo = new BelifeLibrary.Cliente();
                    cliSexo.IdSexo = ComboSexoFiltro.SelectedIndex + 1;
                    DtgClientes.ItemsSource = cliSexo.ReadAllBySexo();

                    //Filtro Sexo, Estado Civil y Rut
                }
                else if (!String.IsNullOrEmpty(TxtRutFiltro.Text) && ComboEstCivilFiltro.SelectedIndex != -1 && ComboSexoFiltro.SelectedIndex != -1)
                {
                    BelifeLibrary.Cliente cliFiltroTotal = new BelifeLibrary.Cliente();
                    cliFiltroTotal.IdEstadoCivil = ComboEstCivilFiltro.SelectedIndex + 1;
                    Clientes = cliFiltroTotal.ReadAllByEstadoCivil();
                    Clientes = Clientes.Where(x => x.IdSexo == ComboSexoFiltro.SelectedIndex + 1 && x.Rut == TxtRutFiltro.Text).ToList();
                    DtgClientes.ItemsSource = Clientes;
                }




                //
                if(String.IsNullOrEmpty(TxtRutFiltro.Text) && ComboEstCivilFiltro.SelectedIndex == -1 && ComboSexoFiltro.SelectedIndex == -1)
                {
                    this.CargarTodosClientes();
                }

                TxtRutFiltro.Text = string.Empty;
                ComboEstCivilFiltro.SelectedIndex = -1;
                ComboSexoFiltro.SelectedIndex = -1;

            }
            catch(Exception ex)
            {

            }


        }
    }
}
