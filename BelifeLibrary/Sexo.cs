using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelifeLibrary
{
    /// <summary>
    /// Crea una nueva instancia de Sexo con sus respectivas validaciones almacenadas en la clase de negocio
    /// <seealso cref="Negocio.Configuracion"/>
    /// </summary>
    public class Sexo
    {
        BeLifeDatos.BeLifeEntities bbdd = new BeLifeDatos.BeLifeEntities();
        private int _id;
        private string _descripcion;
        public int Id
        {
            get { return _id; }
            set
            {
                /*Valida que el id esté dentro del rango aceptado por el modelo de datos*/
                if (Negocio.Configuracion.ValidarIdSexo(value))
                    _id = value;
                else
                    throw new Exception("Error! El id del sexo ingresado no es valido.");
            }
        }
        public string Descripcion
        {
            get { return _descripcion; }
            set
            {
                /*Valida que la descripción del sexo tenga los caracteres minimos y máximos aceptados.*/
                if (Negocio.Configuracion.ValidarDescSexo(value))
                    _descripcion = value;
                else
                    throw new Exception("Error! La descripción del sexo no puede superar los " + Negocio.Configuracion.MAXDESCSEXO + " caracteres.");
            }
        }

        public Sexo()
        {
            InitClass();
        }

        private void InitClass()
        {
            _id = 0;
            _descripcion = String.Empty;
        }


        /// <summary>
        /// Buscamos todos los Sexos de la base de datos y los convertimos a entidades
        /// </summary>
        /// <returns></returns>
        public List<Sexo> ReadAll()
        {
            /*Creamos una lista de Sexos del contexto*/
            List<BeLifeDatos.Sexo> listaDatos = bbdd.Sexo.ToList<BeLifeDatos.Sexo>();

            /*Los convertimos a Sexos legibles*/
            List<Sexo> list = SyncList(listaDatos);

            /*Devolvemos la lista*/
            return list;
        }


        /// <summary>
        /// Metodo para convertir una lista de contexto a lista legible por las librerias.
        /// </summary>
        /// <param name="listaDatos"></param>
        /// <returns></returns>
        private static List<Sexo> SyncList(List<BeLifeDatos.Sexo> listaDatos)
        {
            /*Creamos una lista de Sexos*/
            List<Sexo> list = new List<Sexo>();

            /*Por cada elemento de la lista de Sexos del contexto realizamos una sincronización y los agregamos a la lista de Sexos*/
            foreach (var x in listaDatos)
            {
                Sexo Sexo = new Sexo();
                CommonBC.Syncronize(x, Sexo);
                list.Add(Sexo);

            }

            return list;
        }


    }
}