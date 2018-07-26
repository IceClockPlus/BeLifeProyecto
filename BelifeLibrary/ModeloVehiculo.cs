using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelifeLibrary
{
    public class ModeloVehiculo
    {
        private BeLifeDatos.BeLifeEntities bbdd = new BeLifeDatos.BeLifeEntities();

        public ModeloVehiculo()
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




        public List<ModeloVehiculo> ReadAll()
        {
            List<BeLifeDatos.ModeloVehiculo> listaDatos = bbdd.ModeloVehiculo.ToList<BeLifeDatos.ModeloVehiculo>();

            List<ModeloVehiculo> list = SyncList(listaDatos);

            /*Devolvemos la lista*/
            return list;
        }

        public List<ModeloVehiculo> ReadByMarca(int idMarca)
        {
            var modelos = (from a in bbdd.ModeloVehiculo
                           join b in bbdd.MarcaModeloVehiculo on a.Id equals b.IdModelo
                           where b.IdMarca == idMarca
                           select new ModeloVehiculo
                           {
                               Id = a.Id,
                               Descripcion = a.Descripcion
                           }).ToList();

            return modelos;
        }

        private static List<ModeloVehiculo> SyncList(List<BeLifeDatos.ModeloVehiculo> listaDatos)
        {

            List<ModeloVehiculo> list = new List<ModeloVehiculo>();


            foreach (var x in listaDatos)
            {
                ModeloVehiculo ModeloVehiculo = new ModeloVehiculo();
                CommonBC.Syncronize(x, ModeloVehiculo);
                list.Add(ModeloVehiculo);

            }

            return list;
        }

    }
}
