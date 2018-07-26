using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelifeLibrary
{
    public class Comuna
    {
        private BeLifeDatos.BeLifeEntities bbdd = new BeLifeDatos.BeLifeEntities();

        public int Id { get; set; }
        public string NombreComuna { get; set; }

        public Comuna()
        {
            InitClass();
        }

        private void InitClass()
        {
            Id = 0;
            NombreComuna = String.Empty;
        }





        /// <summary>
        /// Buscamos todos los clientes de la base de datos con el sexo asociado y los convertimos a entidades
        /// </summary>
        /// <returns></returns>
        public List<Comuna> ReadAllByRegion(List<RegionComuna> listaregionescomunas)
        {

            List<Comuna> list = new List<Comuna>();
            Comuna comunalib = new Comuna();

            foreach (var y in listaregionescomunas) {
                var comuna = bbdd.Comuna.Where(x => x.Id == y.IdComuna).SingleOrDefault();
                CommonBC.Syncronize(comuna, comunalib);
                list.Add(comunalib);
            }

            return list;
        }
    

        /// <summary>
        /// Metodo para convertir una lista de contexto a lista legible por las librerias.
        /// </summary>
        /// <param name="listaDatos"></param>
        /// <returns></returns>
        private static List<Comuna> SyncList(List<BeLifeDatos.Comuna> listaDatos)
        {
            /*Creamos una lista de Regiones*/
            List<Comuna> list = new List<Comuna>();

            /*Por cada elemento de la lista de Regiones del contexto realizamos una sincronización y los agregamos a la lista de Regiones*/
            foreach (var x in listaDatos)
            {
                Comuna comuna = new Comuna();
                CommonBC.Syncronize(x, comuna);
                list.Add(comuna);

            }

            return list;
        }

    }
}
