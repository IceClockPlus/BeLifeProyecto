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
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace BeLifeWPF
{
    /// <summary>
    /// Lógica de interacción para AgregarCliente.xaml
    /// </summary>
    public partial class AgregarCliente : Page
    {
        public AgregarCliente()
        {
            InitializeComponent();
            this.CargarEstadoCivil();
            this.CargarSexo();
        }

        private void LimpiarInterfaz()
        {
            TxtRut.Text = string.Empty;
            TxtNombres.Text = string.Empty;
            TxtApellidos.Text = string.Empty;
            DtFechaNacimiento.SelectedDate = DateTime.Today;
            ComboEstadoCivil.SelectedIndex = -1;
            ComboSexo.SelectedIndex = -1;
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

            ComboEstadoCivil.ItemsSource = listadesc;
            ComboEstadoCivil.Items.Refresh();
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

            ComboSexo.ItemsSource = listadesc;
            ComboSexo.Items.Refresh();
        }

        private async void BtnAgregarCliente_Click(object sender, RoutedEventArgs e)
        {
            var metroWindow = (Application.Current.MainWindow as MetroWindow);

            if (TxtRut.Text.Equals(String.Empty) || TxtNombres.Text.Equals(String.Empty) || TxtApellidos.Text.Equals(String.Empty) || DtFechaNacimiento.SelectedDate == null 
            || ComboSexo.SelectedIndex == -1 || ComboEstadoCivil.SelectedIndex == -1)
            {
                
                await metroWindow.ShowMessageAsync("Error!!", "Faltan campos por completar");

            }
            else
            {
                try
                {
                    BelifeLibrary.Cliente cli = new BelifeLibrary.Cliente();
                    cli.Rut = TxtRut.Text;
                    cli.Nombres = TxtNombres.Text;
                    cli.Apellidos = TxtApellidos.Text;
                    cli.FechaNacimiento = (DateTime)DtFechaNacimiento.SelectedDate;
                    cli.IdEstadoCivil = ComboEstadoCivil.SelectedIndex + 1;
                    cli.IdSexo = ComboSexo.SelectedIndex + 1;

                    if (cli.Create())
                    {
                        await metroWindow.ShowMessageAsync("Agregar Cliente", "El cliente fue añadido exitosamente");
                        this.LimpiarInterfaz();
                    }
                    else
                    {
                        await metroWindow.ShowMessageAsync("Error!!", "Ha ocurrido un error");

                    }

                }
                catch (Exception er)
                {
                    await metroWindow.ShowMessageAsync("Error!!", er.Message);

                }


            }


        }

       
    }
}
