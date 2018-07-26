using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Negocio
{
    /// <summary>
    /// Almacena los valores máximos para cada verificación del modelo de entidades.
    /// </summary>
    public class Configuracion
    {
        private static BeLifeDatos.BeLifeEntities bbdd = new BeLifeDatos.BeLifeEntities();


        /* ------------------------------------------------------------------------
*                                CLIENTES
*           Toda la configuración y validaciones de la clase Cliente
  ---------------------------------------------------------------------  */
        public static int MAXRUT = 15;
        public static int MAXNOMBRE = 20;
        public static int MAXAPELLIDO = 20;
        public static int MINEDAD = 18;


        // ------------------ Métodos validaciones Cliente ----------------------
        /// <summary>
        /// Metodo para validar nuevo rut del cliente
        /// </summary>
        /// <param name="value"></param>
        /// Value: Nuevo rut cliente.
        /// <returns></returns>
        public static bool ValidarRut(string value)
        {
            bool validated = false;
            if (!value.Equals(String.Empty) && value.Length < MAXRUT) {
                validated = true;
            }
            return validated;
        }

        /// <summary>
        /// Metodo para validar nuevo Nombre del cliente
        /// </summary>
        /// <param name="value"></param>
        /// Value: Nuevo Nombre cliente.
        /// <returns></returns>
        public static bool ValidarNombre(string value)
        {
            bool validated = false;
            if (!value.Equals(String.Empty) && value.Length < MAXNOMBRE)
            {
                validated = true;
            }
            return validated;
        }

        /// <summary>
        /// Metodo para validar nuevo Apellido del cliente
        /// </summary>
        /// <param name="value"></param>
        /// Value: Nuevo Apellido cliente.
        /// <returns></returns>
        public static bool ValidarApellido(string value)
        {
            bool validated = false;
            if (!value.Equals(String.Empty) && value.Length < MAXAPELLIDO)
                validated = true;

            return validated;
        }

        /// <summary>
        /// Metodo para validar nueva fecha de nacimiento del cliente
        /// </summary>
        /// <param name="value"></param>
        /// Value: Nueva Fecha de nacimiento del cliente.
        /// <returns></returns>
        public static bool ValidarFechaNacimiento(DateTime value) {
            bool validated = false;
            int age = CalcularEdad(value);
            if (age >= MINEDAD)
                validated = true;

            return validated;
        }

        public static int CalcularEdad(DateTime value) {
            DateTime today = DateTime.Today;
            int age = today.Year - value.Year;

            return age;
        }




        /* ------------------------------------------------------------------------
         *                                CONTRATOS
         *        Toda la configuración y validaciones de la clase Contratos
           ---------------------------------------------------------------------  */
        public static int MAXNUMCONTRATO = 14;
        public static int MAXCODIGOPLAN = 5;
        public static int MAXIDPLAN = 5;
        public static int MAXPOLIZAACTUAL = 15;
        public static DateTime MAXFECHACONTRATO = DateTime.Today.AddMonths(+1);
        public static DateTime MINFECHACONTRATO = DateTime.Today;

        // -------------------- Métodos validaciones Contrato ------------------------
        /// <summary>
        /// Metodo para validar nuevo Numero de Contrato
        /// </summary>
        /// <param name="value"></param>
        /// Value: Nuevo Numero Contrato.
        /// <returns></returns>
        public static bool ValidarNumContrato(string value)
        {
            bool validated = false;
            if (!value.Equals(String.Empty) && value.Length < MAXNUMCONTRATO)
            {
                validated = true;
            }
            return validated;
        }

        /// <summary>
        /// Metodo para validar nuevo CodigoPlan
        /// </summary>
        /// <param name="value"></param>
        /// Value: Nuevo Codigo Plan.
        /// <returns></returns>
        public static bool ValidarCodigoPlan(string value)
        {
            bool validated = false;
            var plan = bbdd.Plan.First(x => x.Id == value);
            if (!value.Equals(String.Empty) && value.Length < MAXCODIGOPLAN && plan != null)
            {
                validated = true;
            }
            return validated;
        }

        /// <summary>
        /// Metodo para validar nuevo ID Plan
        /// </summary>
        /// <param name="value"></param>
        /// Value: Nuevo ID Plan.
        /// <returns></returns>
        public static bool ValidarIdPlan(string value)
        {
            bool validated = false;
            if (!value.Equals(String.Empty) && value.Length < MAXIDPLAN)
            {
                validated = true;
            }
            return validated;
        }

        /// <summary>
        /// Metodo para validar nueva Poliza Actual
        /// </summary>
        /// <param name="value"></param>
        /// Value: Nueva Poliza Actual.
        /// <returns></returns>
        public static bool ValidarPolizaActual(string value)
        {
            bool validated = false;
            if (!value.Equals(String.Empty) && value.Length < MAXPOLIZAACTUAL)
            {
                validated = true;
            }
            return validated;
        }

        /// <summary>
        /// Creamos el nuevo numero de contacto
        /// Se genera automáticamente según la fecha y hora de creación del contrato.
        /// Formato: AAAAMMDDHHmmSS
        /// </summary>
        public static string CrearNumeroContrato() {
            string num = String.Empty;
            try
            {
                num = DateTime.Now.ToString("yyyyMMddHHmmss");
            }
            catch (Exception e) {
                throw e;
            }

            return num;
        }

        /// <summary>
        /// Creamos la fecha de termino a exactamente 1 año después de la fecha de creación.
        /// </summary>
        /// <returns>DateTime.Today + 1 año</returns>
        public static DateTime CrearFechaTermino() {
            DateTime FechaTermino = DateTime.Today.AddYears(+1);

            return FechaTermino;
        }

        /// <summary>
        /// Validamos que la fecha de contrato no sea mayor a la fecha actual, ni que exceda 1 mes
        /// </summary>
        public static bool ValidarFechaInicioContrato(DateTime value) {

            bool validated = false;
            if (value > MINFECHACONTRATO && value < MAXFECHACONTRATO)
                validated = true;

            return validated;
        }




        /* ------------------------------------------------------------------------
         *                                SEXO
         *           Toda la configuración y validaciones de la clase Sexo
           ---------------------------------------------------------------------  */
        public static int MAXDESCSEXO = 10;

        // -------------------- Métodos validaciones Sexo ------------------------
        /// <summary>
        /// Metodo para validar nuevo Descripcion del sexo
        /// </summary>
        /// <param name="value"></param>
        /// Value: Nuevo Descripcion Sexo.
        /// <returns></returns>
        public static bool ValidarDescSexo(string value)
        {
            bool validated = false;
            if (!value.Equals(String.Empty) && value.Length < MAXDESCSEXO)
            {
                validated = true;
            }
            return validated;
        }

        /// <summary>
        /// Verifica que el id ingresado exista dentro del rango del modelo de datos.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool ValidarIdSexo(int value)
        {
            bool validated = false;
            var sexo = bbdd.Sexo.First(x => x.Id == value);

            if (sexo != null)
                validated = true;

            return validated;
        }




        /* ------------------------------------------------------------------------
         *                                ESTADO CIVIL
         *        Toda la configuración y validaciones de la clase Estado Civil
           ---------------------------------------------------------------------  */
        public static int MAXDESCESTCIVIL = 15;

        // -------------------- Métodos validaciones Estado Civil -----------------
        /// <summary>
        /// Metodo para validar nuevo Descripcion del Estado Civil
        /// </summary>
        /// <param name="value"></param>
        /// Value: Nuevo Descripcion Estado Civil.
        /// <returns></returns>
        public static bool ValidarDescEstadoCivil(string value)
        {
            bool validated = false;
            if (!value.Equals(String.Empty) && value.Length < MAXDESCESTCIVIL)
            {
                validated = true;
            }
            return validated;
        }

        /// <summary>
        /// Verifica que el id ingresado exista dentro del rango del modelo de datos.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool ValidarIdEstadoCivil(int value)
        {
            bool validated = false;
            var estadoCivil = bbdd.EstadoCivil.First(x => x.Id == value);

            if (estadoCivil != null)
                validated = true;

            return validated;
        }

        /* ------------------------------------------------------------------------
         *                                TIPO CONTRATO
         *        Toda la configuración y validaciones de la clase Estado Civil
           ---------------------------------------------------------------------  */
        public static int MAXDESCTIPOCONTRATO = 15;
        public static int MINDESCTIPOCONTRATO = 0;

        /// <summary>
        /// Verifica que la descripción del tipo de contrato se adapte al modelo de datos.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool ValidarDescTipoContrato(string value)
        {
            bool validated = false;

            if (value.Length > MINDESCTIPOCONTRATO && value.Length <= MAXDESCTIPOCONTRATO)
                validated = true;

            return validated;
        }


        /* ------------------------------------------------------------------------
         *                                VEHICULO
         *        Toda la configuración y validaciones de la clase Estado Civil
           ---------------------------------------------------------------------  */
        public static int MINANHOV = 1980;
        public static int MAXANHOV = DateTime.Now.Year;

        public static bool ValidarAnhoVehiculo(int value)
        {
            bool validated = false;

            if (value >= MINANHOV && value <= MAXANHOV)
                validated = true;


            return validated;
        }


        public static bool ValidarPatente(string value)
        {
            bool validated = false;

            if (!value.Equals(String.Empty) && !value.Equals(null) && !value.Equals(""))
                validated = true;

            // AAAA99
            string regex1 = "^[A-Z]{4}[0-9]{2}$";

            // AAA999
            string regex2 = "^[A-Z]{3}[0-9]{3}$";

            // AA9999
            string regex3 = "^[A-Z]{2}[0-9]{4}$";

            if (
                Regex.Match(value, regex1).Success ||
                Regex.Match(value, regex2).Success ||
                Regex.Match(value, regex3).Success
                )
            {
                // Patente Válida :D
                validated = true;
            }
            else
            {
                // Patente no valida
                validated = false;
            }

            return validated;
        }



        /* ------------------------------------------------------------------------
         *                                VIVIENDA
         *        Toda la configuración y validaciones de la clase Estado Civil
           ---------------------------------------------------------------------  */
        public static int MINCODPOSTAL = 1000000;
        public static int MAXCODPOSTAL = 9999999;
        public static int MINANHO = 1910;
        public static int MAXANHO = DateTime.Now.Year;

        /// <summary>
        /// Validamos que el codigo postal esté dentro de los parametros permitidos.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool ValidarCodigoPostal(int value)
        {
            bool validated = false;

            /*Si la vivienda tiene un codigo postal permitido, devolvemos verdadero.*/
            if (value >= MINCODPOSTAL && value <= MAXCODPOSTAL)
                validated = true;


            return validated;
        }

        /// <summary>
        /// Validamos que la vivienda tenga un año correcto (1910 hasta el año actual)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool ValidarAnhoVivienda(int value)
        {
            bool validated = false;

            if (value >= MINANHO && value <= MAXANHO)
                validated = true;


            return validated;
        }

        /// <summary>
        /// La dirección es obligatoria.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool ValidarDireccion(string value)
        {
            bool validated = false;

            if (!value.Equals(String.Empty))
                validated = true;

            return validated;
        }

        /// <summary>
        /// Valida que el valor de Inmueble contenga algún valor.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool ValidarInmueble(double value)
        {
            bool validated = false;

            if (value > 0)
                validated = true;

            return validated;
        }

    }
}
