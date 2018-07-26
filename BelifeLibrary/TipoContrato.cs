using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeLifeDatos;

namespace BelifeLibrary
{
    public class TipoContrato
    {
        BeLifeDatos.BeLifeEntities bbdd = new BeLifeDatos.BeLifeEntities();
        private int _id { get; set; }
        private string _descripcion { get; set; }
        public int Id {
            get { return _id; }

            set {
                _id = value;
            }
        }

        public string Descripcion {

            get { return _descripcion; }

            set
            {
                if (Negocio.Configuracion.ValidarDescTipoContrato(value))
                {
                    _descripcion = value;
                }
                else
                {
                    throw new Exception("La descripción del tipo de contrato debe ser mayor a " + Negocio.Configuracion.MINDESCTIPOCONTRATO + " y menor o igual a "+Negocio.Configuracion.MAXDESCTIPOCONTRATO+" caracteres.");
                }
            }
        }

        public TipoContrato() {

            InitClass();

        }

        private void InitClass()
        {
            _id = 0;
            _descripcion = String.Empty;
        }

        /// <summary>
        /// Buscamos todos los TipoContratos de la base de datos y los convertimos a entidades
        /// </summary>
        /// <returns></returns>
        public List<TipoContrato> ReadAll()
        {
            
            /*Creamos una lista de TipoContratos del contexto*/
            List<BeLifeDatos.TipoContrato> listaDatos = bbdd.TipoContrato.ToList<BeLifeDatos.TipoContrato>();

            /*Los convertimos a TipoContratos legibles*/
            List<TipoContrato> list = SyncList(listaDatos);

            /*Devolvemos la lista*/
            return list;
        }


        /// <summary>
        /// Metodo para convertir una lista de contexto a lista legible por las librerias.
        /// </summary>
        /// <param name="listaDatos"></param>
        /// <returns></returns>
        private static List<TipoContrato> SyncList(List<BeLifeDatos.TipoContrato> listaDatos)
        {
            /*Creamos una lista de TipoContratos*/
            List<TipoContrato> list = new List<TipoContrato>();

            /*Por cada elemento de la lista de TipoContratos del contexto realizamos una sincronización y los agregamos a la lista de TipoContratos*/
            foreach (var x in listaDatos)
            {
                TipoContrato TipoContrato = new TipoContrato();
                CommonBC.Syncronize(x, TipoContrato);
                list.Add(TipoContrato);

            }

            return list;
        }


    }
}
