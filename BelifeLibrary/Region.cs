using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelifeLibrary
{
    public class Region
    {
        private BeLifeDatos.BeLifeEntities bbdd = new BeLifeDatos.BeLifeEntities();


        public Region()
        {
            InitClass();
        }

        private void InitClass()
        {
            Id = 0;
            NombreRegion = String.Empty;
        }

        public int Id { get; set; }
        public string NombreRegion { get; set; }

        /// <summary>
        /// Buscamos todos los clientes de la base de datos y los convertimos a entidades
        /// </summary>
        /// <returns></returns>
        public List<Region> ReadAll()
        {
            /*Creamos una lista de clientes del contexto*/
            List<BeLifeDatos.Region> listaDatos = bbdd.Region.ToList<BeLifeDatos.Region>();

            /*Los convertimos a Clientes legibles*/
            List<Region> list = SyncList(listaDatos);

            /*Devolvemos la lista*/
            return list;
        }



        /// <summary>
        /// Metodo para convertir una lista de contexto a lista legible por las librerias.
        /// </summary>
        /// <param name="listaDatos"></param>
        /// <returns></returns>
        private static List<Region> SyncList(List<BeLifeDatos.Region> listaDatos)
        {
            /*Creamos una lista de Regiones*/
            List<Region> list = new List<Region>();

            /*Por cada elemento de la lista de Regiones del contexto realizamos una sincronización y los agregamos a la lista de Regiones*/
            foreach (var x in listaDatos)
            {
                Region region = new Region();
                CommonBC.Syncronize(x, region);
                list.Add(region);

            }

            return list;
        }

    }
}
