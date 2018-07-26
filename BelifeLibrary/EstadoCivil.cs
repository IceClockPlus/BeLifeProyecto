using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelifeLibrary
{
    public class EstadoCivil
    {
        BeLifeDatos.BeLifeEntities bbdd = new BeLifeDatos.BeLifeEntities();
        private int _id;
        private string _descripcion;
        public int Id {
            get { return _id; }
            set
            {
                if (Negocio.Configuracion.ValidarIdEstadoCivil(value))
                    _id = value;
                else
                    throw new Exception("Error! El id del EstadoCivil ingresado no es valido.");
            }
        }
        public string Descripcion {
            get { return _descripcion; }
            set
            {
                if (Negocio.Configuracion.ValidarDescEstadoCivil(value))
                    _descripcion = value;
                else
                    throw new Exception("Error! La descripción del estado civil no puede superar los " + Negocio.Configuracion.MAXDESCESTCIVIL + " caracteres.");
            }
        }

        public EstadoCivil() {
            InitClass();
        }

        private void InitClass()
        {
            _id = 0;
            _descripcion = String.Empty;
        }


        /// <summary>
        /// Buscamos todos los EstadoCivils de la base de datos y los convertimos a entidades
        /// </summary>
        /// <returns></returns>
        public List<EstadoCivil> ReadAll()
        {
            /*Creamos una lista de EstadoCivils del contexto*/
            List<BeLifeDatos.EstadoCivil> listaDatos = bbdd.EstadoCivil.ToList<BeLifeDatos.EstadoCivil>();

            /*Los convertimos a EstadoCivils legibles*/
            List<EstadoCivil> list = SyncList(listaDatos);

            /*Devolvemos la lista*/
            return list;
        }


        /// <summary>
        /// Metodo para convertir una lista de contexto a lista legible por las librerias.
        /// </summary>
        /// <param name="listaDatos"></param>
        /// <returns></returns>
        private static List<EstadoCivil> SyncList(List<BeLifeDatos.EstadoCivil> listaDatos)
        {
            /*Creamos una lista de EstadoCivils*/
            List<EstadoCivil> list = new List<EstadoCivil>();

            /*Por cada elemento de la lista de EstadoCivils del contexto realizamos una sincronización y los agregamos a la lista de EstadoCivils*/
            foreach (var x in listaDatos)
            {
                EstadoCivil EstadoCivil = new EstadoCivil();
                CommonBC.Syncronize(x, EstadoCivil);
                list.Add(EstadoCivil);

            }

            return list;
        }

    }
}