using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelifeLibrary
{
    public class Vivienda
    {

        public Vivienda()
        {
            InitClass();
        }

        private void InitClass()
        {
            CodigoPostal = 0;
            Anho = 0;
            Direccion = String.Empty;
            ValorContenido = 0;
            ValorInmueble = 0;
            IdRegion = 0;
            IdComuna = 0;
        }

        private int _codigoPostal;

        public int CodigoPostal {
            get { return _codigoPostal; }
            set
            {
                if (Negocio.Configuracion.ValidarCodigoPostal(value))
                {
                    _codigoPostal = value;
                }
                else
                {
                    throw new Exception("El codigo postal es incorrecto, el valor debe ser entre " + Negocio.Configuracion.MINCODPOSTAL + " y "+Negocio.Configuracion.MAXCODPOSTAL+"");
                }
            }
        }

        private int _anho { get; set; }

        public int Anho {
            get { return _anho; }
            set
            {
                if (Negocio.Configuracion.ValidarAnhoVivienda(value))
                    _anho = value;
                else
                    throw new Exception("El año es invalido, intenta con un valor entre 1910 y " + Negocio.Configuracion.MAXANHO + "");
            }
        }

        private string _direccion { get; set; }

        public string Direccion {
            get { return _direccion; }
            set
            {
                if (Negocio.Configuracion.ValidarDireccion(value))
                    _direccion = value;
                else
                    throw new Exception("La dirección es obligatoria.");
            }
        }
        public double ValorInmueble { get; set; }
        public double ValorContenido { get; set; }
        public int IdRegion { get; set; }
        public int IdComuna { get; set; }

    }
}
