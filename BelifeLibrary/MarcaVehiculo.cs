using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelifeLibrary
{
    public class MarcaVehiculo
    {
        private BeLifeDatos.BeLifeEntities bbdd = new BeLifeDatos.BeLifeEntities();


        public MarcaVehiculo()
        {
            InitClass();
        }

        private void InitClass()
        {
            Id = 0;
            Descripcion = String.Empty;
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public List<MarcaVehiculo> ReadAll()
        {
            /*Creamos una lista de EstadoCivils del contexto*/
            List<BeLifeDatos.MarcaVehiculo> listaDatos = bbdd.MarcaVehiculo.ToList<BeLifeDatos.MarcaVehiculo>();

            /*Los convertimos a EstadoCivils legibles*/
            List<MarcaVehiculo> list = SyncList(listaDatos);

            /*Devolvemos la lista*/
            return list;
        }

        private static List<MarcaVehiculo> SyncList(List<BeLifeDatos.MarcaVehiculo> listaDatos)
        {
            /*Creamos una lista de EstadoCivils*/
            List<MarcaVehiculo> list = new List<MarcaVehiculo>();

            /*Por cada elemento de la lista de EstadoCivils del contexto realizamos una sincronización y los agregamos a la lista de EstadoCivils*/
            foreach (var x in listaDatos)
            {
                MarcaVehiculo MarcaVehiculo = new MarcaVehiculo();
                CommonBC.Syncronize(x, MarcaVehiculo);
                list.Add(MarcaVehiculo);

            }

            return list;
        }

    }
}
