using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelifeLibrary
{
    public class MarcaModeloVehiculo
    {
        private BeLifeDatos.BeLifeEntities bbdd = new BeLifeDatos.BeLifeEntities();

        public MarcaModeloVehiculo()
        {
            InitClass();
        }

        private void InitClass()
        {
            IdMarca = 0;
            IdModelo = 0;
        }

        public int IdMarca { get; set; }
        public int IdModelo { get; set; }


        public List<MarcaModeloVehiculo> ReadAll()
        {
            /*Creamos una lista de EstadoCivils del contexto*/
            List<BeLifeDatos.MarcaModeloVehiculo> listaDatos = bbdd.MarcaModeloVehiculo.ToList<BeLifeDatos.MarcaModeloVehiculo>();

            /*Los convertimos a EstadoCivils legibles*/
            List<MarcaModeloVehiculo> list = SyncList(listaDatos);

            /*Devolvemos la lista*/
            return list;
        }

        


        private static List<MarcaModeloVehiculo> SyncList(List<BeLifeDatos.MarcaModeloVehiculo> listaDatos)
        {
            
            List<MarcaModeloVehiculo> list = new List<MarcaModeloVehiculo>();

            
            foreach (var x in listaDatos)
            {
                MarcaModeloVehiculo MarcaModeloVehiculo = new MarcaModeloVehiculo();
                CommonBC.Syncronize(x, MarcaModeloVehiculo);
                list.Add(MarcaModeloVehiculo);

            }

            return list;
        }

    }
}
