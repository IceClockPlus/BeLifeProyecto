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
    /// Lógica de interacción para AgregarContrato.xaml
    /// </summary>
    public partial class AgregarContrato : Page

    {
        List<BelifeLibrary.ModeloVehiculo> model = new List<BelifeLibrary.ModeloVehiculo>();

        public AgregarContrato()
        {
            InitializeComponent();
            this.CargarTipoContrato();
            this.CargarMarcasVehiculo();

           

        }


        private void CargarMarcasVehiculo()
        {
            BelifeLibrary.MarcaVehiculo marca = new BelifeLibrary.MarcaVehiculo();
            List<BelifeLibrary.MarcaVehiculo> marcas = new List<BelifeLibrary.MarcaVehiculo>();
            List<String> listdesc = new List<string>();
            marcas = marca.ReadAll();
            foreach(var x in marcas)
            {
                listdesc.Add(x.Descripcion);
            }
            ComboMarca.ItemsSource = listdesc;
            ComboMarca.Items.Refresh();
        }

        private void CargarTipoContrato()
        {
            BelifeLibrary.TipoContrato tipocon = new BelifeLibrary.TipoContrato();
            List<BelifeLibrary.TipoContrato> tipos = new List<BelifeLibrary.TipoContrato>();
            List<String> listdesc = new List<string>();
            tipos = tipocon.ReadAll();
            foreach(var x in tipos)
            {
                listdesc.Add(x.Descripcion);
            }
            ComboTipoContratos.ItemsSource = listdesc;
            ComboTipoContratos.Items.Refresh();

        }




        private void ComboTipoContratos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<BelifeLibrary.Plan> Planes = new List<BelifeLibrary.Plan>();
            List<String> desc = new List<string>();
            BelifeLibrary.Plan  pl = new BelifeLibrary.Plan();
            


            if (ComboTipoContratos.SelectedIndex == 0)
            {
                this.GridSalud.Visibility = System.Windows.Visibility.Visible;
                this.GridVehiculo.Visibility = System.Windows.Visibility.Hidden;
                this.GridVivienda.Visibility = System.Windows.Visibility.Hidden;
                Planes = pl.ReadAllByVida();

            }
            else if (ComboTipoContratos.SelectedIndex == 1)
            {
                this.GridVehiculo.Visibility = System.Windows.Visibility.Visible;
                this.GridSalud.Visibility = System.Windows.Visibility.Hidden;
                this.GridVivienda.Visibility = System.Windows.Visibility.Hidden;
                Planes = pl.ReadAllByVehiculo();

            }
            else if(ComboTipoContratos.SelectedIndex == 2)
            {
                this.GridVivienda.Visibility = System.Windows.Visibility.Visible;
                this.GridSalud.Visibility = System.Windows.Visibility.Hidden;
                this.GridVehiculo.Visibility = System.Windows.Visibility.Hidden;
                Planes = pl.ReadAllByHogar();
            }

            if(ComboTipoContratos.SelectedIndex != -1)
            {
                foreach(var x in Planes)
                {
                    desc.Add(x.Nombre);
                }
                ComboPlanes.ItemsSource = desc;
            }
            else
            {
                ComboPlanes.ItemsSource = null;
            }


        }

        private void BtnAgregarConVeh_Click(object sender, RoutedEventArgs e)
        {

            BelifeLibrary.Cliente cli = new BelifeLibrary.Cliente();
            cli.Rut = TxtRut.Text;
            cli.Read();

            BelifeLibrary.Contrato con = new BelifeLibrary.Contrato();
            con.Titular = cli;

            BelifeLibrary.Plan pl = new BelifeLibrary.Plan();
            pl.ReadAllByVehiculo();
            con.PlanAsociado = pl;
            con.FechaInicioVigencia = (DateTime)DtFechaVigencia.SelectedDate;




        }

        private void ComboMarca_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BelifeLibrary.MarcaVehiculo marca = new BelifeLibrary.MarcaVehiculo();
            marca.Id = ComboMarca.SelectedIndex + 1;

            BelifeLibrary.ModeloVehiculo modelo = new BelifeLibrary.ModeloVehiculo();
            List<BelifeLibrary.ModeloVehiculo> Modelos = new List<BelifeLibrary.ModeloVehiculo>();
            List<String> listdesc = new List<string>();
            Modelos = modelo.ReadByMarca(marca.Id);
            model = modelo.ReadByMarca(marca.Id);
            foreach(var x in Modelos)
            {
                listdesc.Add(x.Descripcion);
            }

            ComboModelo.ItemsSource = listdesc;
            

        }

        private async void BtnAgregarConVida_Click(object sender, RoutedEventArgs e)
        {
            
            
            var metroWindow = (Application.Current.MainWindow as MetroWindow);
            try
            {
                BelifeLibrary.Plan pl = new BelifeLibrary.Plan();
                List<BelifeLibrary.Plan> Planes = new List<BelifeLibrary.Plan>();
                Planes = pl.ReadAll();



                BelifeLibrary.Contrato con = new BelifeLibrary.Contrato();
                BelifeLibrary.Cliente cli = new BelifeLibrary.Cliente();
                cli.Rut = TxtRut.Text;
                cli.Read();

                
                con.PlanAsociado = pl;
                con.FechaInicioVigencia = (DateTime)DtFechaVigencia.SelectedDate;
                con.Observaciones = TxtObservaciones.Text;
                if (con.Create())
                {
                    await metroWindow.ShowMessageAsync("Agregar Contrato", "El contrato fue añadido exitosamente");
                }
               
            }
            catch (Exception er)
            {

                await metroWindow.ShowMessageAsync("Error!!", er.Message);
            }

        }
    }
}
