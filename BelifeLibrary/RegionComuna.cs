using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelifeLibrary
{
    public class RegionComuna
    {
        private BeLifeDatos.BeLifeEntities bbdd = new BeLifeDatos.BeLifeEntities();

        public RegionComuna()
        {
            InitClass();
        }

        private void InitClass()
        {
            IdRegion = 0;
            IdComuna = 0;
        }

        public int IdRegion { get; set; }
        public int IdComuna { get; set; }


        /// <summary>
        /// Buscamos todos los clientes de la base de datos con el sexo asociado y los convertimos a entidades
        /// </summary>
        /// <returns></returns>
        public List<RegionComuna> ReadAllByRegionComuna(int IdRegion)
        {
            /*Creamos una lista de clientes del contexto*/
            List<BeLifeDatos.RegionComuna> listaDatos = bbdd.RegionComuna.Where(x => x.IdRegion == IdRegion).ToList();

            /*Los convertimos a Clientes legibles*/
            List<RegionComuna> list = SyncList(listaDatos);

            /*Devolvemos la lista*/
            return list;
        }

        /// <summary>
        /// Metodo para convertir una lista de contexto a lista legible por las librerias.
        /// </summary>
        /// <param name="listaDatos"></param>
        /// <returns></returns>
        private static List<RegionComuna> SyncList(List<BeLifeDatos.RegionComuna> listaDatos)
        {
            /*Creamos una lista de Regiones*/
            List<RegionComuna> list = new List<RegionComuna>();

            /*Por cada elemento de la lista de Regiones del contexto realizamos una sincronización y los agregamos a la lista de Regiones*/
            foreach (var x in listaDatos)
            {
                RegionComuna regioncomuna = new RegionComuna();
                CommonBC.Syncronize(x, regioncomuna);
                list.Add(regioncomuna);

            }

            return list;
        }

    }
}
