using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelifeLibrary
{
    public class Tarificador
    {
        private BeLifeDatos.BeLifeEntities bbdd = new BeLifeDatos.BeLifeEntities();
        public Cliente Cliente { get; set; }


        public Tarificador() {
            InitClass();
        }

        private void InitClass()
        {
            Cliente = new Cliente();
        }

        public float CalcularPrima(string Id) {


            var prima1 = bbdd.Plan.First(x => x.Id == Id);
            float prima = (float) prima1.PrimaBase;
            int idSexo = Cliente.IdSexo;
            int idEstadoCivil = Cliente.IdEstadoCivil;
            int age = Negocio.Configuracion.CalcularEdad(Cliente.FechaNacimiento);

            if (age >= 18 && age <= 25)
                prima += 3.6f;
            else if (age > 25 && age <= 45)
                prima += 2.4f;
            else if (age > 45)
                prima += 6f;

            if (idSexo == 1)
                prima += 2.4f;
            else if (idSexo == 2)
                prima += 1.2f;

            if (idEstadoCivil == 1)
                prima += 4.8f;
            else if (idEstadoCivil == 2)
                prima += 2.4f;
            else
                prima += 3.6f;

            return prima;

        } 
    }
}
