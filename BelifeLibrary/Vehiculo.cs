using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelifeLibrary
{
    public class Vehiculo : ITarificador
    {

        private BeLifeDatos.BeLifeEntities bbdd = new BeLifeDatos.BeLifeEntities();

        public Vehiculo()
        {
            InitClass();
        }

        private void InitClass()
        {
            _patente = String.Empty;
            IdMarca = 0;
            IdModelo = 0;
            _anho = 0;
        }

        private string _patente;

        public string Patente {
            get { return _patente; }
            set
            {
                if (Negocio.Configuracion.ValidarPatente(value))
                    _patente = value;
                else
                    throw new Exception("La patente es invalida.");
            }
        }
        public int IdMarca { get; set; }
        public int IdModelo { get; set; }

        private int _anho { get; set; }
        public int Anho {
            get { return _anho; }

            set
            {
                if (Negocio.Configuracion.ValidarAnhoVehiculo(value))
                    _anho = value;
                else
                    throw new Exception("Año del vehiculo invalido.");
            }
        }

        public Cliente Cliente { get; set ; }


        /// <summary>
        /// Agrega un vehiculo nuevo a la base de datos, verificando que no exista uno previamente.
        /// <seealso cref="BuscarCliente(string)"/>
        /// </summary>
        /// <param name="lcl"></param>
        public bool Create()
        {
            try
            {
                /*Intenta buscar el vehiculo asociado al rut del cliente que se desea agregar.*/
                var vehiculo = bbdd.Vehiculo.Where(x => x.Patente == Patente).SingleOrDefault();
                if (vehiculo != null)
                {
                    /*En caso de que lo encuentre, levanta una excepción*/
                    throw new Exception("Error! Ya existe un vehiculo con esa patente.");
                }
                /*No se encontró el rut del cliente, por lo que el cliente no existe.*/
                else
                {
                    /*Agregamos el cliente*/
                    BeLifeDatos.Vehiculo veh = new BeLifeDatos.Vehiculo();
                    CommonBC.Syncronize(this, veh);
                    bbdd.Vehiculo.Add(veh);
                    bbdd.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                /*En caso de encontrar alguna excepción, la imprime en consola y se la envía al WPF para controlar el mensaje*/
                Console.Write(ex);
                throw ex;

            }


        }



        /// <summary>
        /// Busca un vehiculo que coincida con la patente entregada como parametro.
        /// En caso de ser encontrado, crea una nueva instancia Vehiculo de la librería de clases, y la retorna.
        /// </summary>
        /// <returns>this</returns>
        public Vehiculo Read()
        {
            try
            {
                /*Busca vehiculo con la patente entregada*/
                var vehiculo = bbdd.Vehiculo.Where(x => x.Patente == Patente).SingleOrDefault();

                /*Si el cliente es distinto a null, significa que se encontró, por lo que creamos un nuevo cliente de la
                 librería de clases para retornar.*/
                if (vehiculo != null)
                {
                    CommonBC.Syncronize(vehiculo, this);
                    return this;
                }
                else
                    throw new Exception("No se ha encontrado un vehiculo con la patente asociada.");



            }
            catch (Exception ex)
            {
                /*En caso de encontrar alguna excepción, la imprime en consola y se la envía al WPF para controlar el mensaje*/
                Console.Write(ex);
                throw ex;
            }
        }


        /// <summary>
        /// Eliminarmos el vehiculo que posea la patente de la instancia
        /// Realiza una verificación si es que existe el vehiculo.
        /// <seealso cref="Buscar()"/>
        /// </summary>
        public bool Delete()
        {
            try
            {
                /*Buscamos un cliente asociado al rut*/
                var vehiculo = bbdd.Vehiculo.Where(x => x.Patente == Patente).SingleOrDefault();
                /*Si lo encuentra lo elimina*/
                if (vehiculo != null)
                {
                    bbdd.Vehiculo.Remove(vehiculo);
                    bbdd.SaveChanges();
                    return true;
                }
                else
                {
                    /*Si no lo encuentra, levanta una excepción.*/
                    throw new Exception("No se ha encontrado una patente coincidente.");
                }

            }
            catch (Exception ex)
            {
                /*En caso de encontrar alguna excepción, la imprime en consola y se la envía al WPF para controlar el mensaje*/
                Console.Write(ex);
                return false;
                throw ex;
            }

        }


        /// <summary>
        /// Actualiza un cliente con el rut dado
        /// Modifica sus valores con los valores del nuevo cliente (modifica todo menos el rut)
        /// </summary>
        public bool Update()
        {

            try
            {
                /*Busca cliente con el rut entregado*/
                var vehiculo = bbdd.Vehiculo.Where(x => x.Patente == Patente).SingleOrDefault();
                if (vehiculo != null)
                {
                    /*En caso de que el cliente no sea null, es decir, que lo haya encontrado, lo actualizamos y guardamos cambios.*/
                    CommonBC.Syncronize(this, vehiculo);
                    bbdd.SaveChanges();
                    return true;
                }
                else
                {
                    /*En caso de no encontrar un cliente con el rut asociado, enviamos una excepción*/
                    throw new Exception("No se ha encontrado una patente coincidente.");
                }

            }
            catch (Exception ex)
            {
                /*En caso de encontrar alguna excepción, la imprime en consola y se la envía al WPF para controlar el mensaje*/
                Console.Write(ex);
                return false;
                throw ex;
            }

        }

        /// <summary>
        /// Buscamos todos los clientes de la base de datos y los convertimos a entidades
        /// </summary>
        /// <returns></returns>
        public List<Vehiculo> ReadAll()
        {
            /*Creamos una lista de clientes del contexto*/
            List<BeLifeDatos.Vehiculo> listaDatos = bbdd.Vehiculo.ToList<BeLifeDatos.Vehiculo>();

            /*Los convertimos a Clientes legibles*/
            List<Vehiculo> list = SyncList(listaDatos);

            /*Devolvemos la lista*/
            return list;
        }

        /// <summary>
        /// Buscamos todos los clientes de la base de datos con el sexo asociado y los convertimos a entidades
        /// </summary>
        /// <returns></returns>
        public List<Vehiculo> ReadAllByMarca()
        {
            /*Creamos una lista de clientes del contexto*/
            List<BeLifeDatos.Vehiculo> listaDatos = bbdd.Vehiculo.Where(x => x.IdMarca == IdMarca).ToList();

            /*Los convertimos a Clientes legibles*/
            List<Vehiculo> list = SyncList(listaDatos);

            /*Devolvemos la lista*/
            return list;
        }

        /// <summary>
        /// Buscamos todos los clientes de la base de datos con el estado civil asociado y los convertimos a entidades
        /// </summary>
        /// <returns></returns>
        public List<Vehiculo> ReadAllByModelo()
        {
            /*Creamos una lista de clientes del contexto*/
            List<BeLifeDatos.Vehiculo> listaDatos = bbdd.Vehiculo.Where(x => x.IdModelo == IdModelo).ToList();

            /*Los convertimos a Clientes legibles*/
            List<Vehiculo> list = SyncList(listaDatos);

            /*Devolvemos la lista*/
            return list;
        }

        /// <summary>
        /// Metodo para convertir una lista de contexto a lista legible por las librerias.
        /// </summary>
        /// <param name="listaDatos"></param>
        /// <returns></returns>
        private static List<Vehiculo> SyncList(List<BeLifeDatos.Vehiculo> listaDatos)
        {
            /*Creamos una lista de clientes*/
            List<Vehiculo> list = new List<Vehiculo>();

            /*Por cada elemento de la lista de clientes del contexto realizamos una sincronización y los agregamos a la lista de Clientes*/
            foreach (var x in listaDatos)
            {
                Vehiculo vehiculo = new Vehiculo();
                CommonBC.Syncronize(x, vehiculo);
                list.Add(vehiculo);

            }

            return list;
        }

        public int CalcularEdad(DateTime value)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - value.Year;

            return age;
        }

        public double CalcularPrima()
        {
            double prima = 0;

            int edad = this.CalcularEdad(Cliente.FechaNacimiento);

            if(edad >= 18 && edad <= 25)
            {
                prima = prima + 1.2d;
            }else if (edad > 25 && edad <= 45)
            {
                prima = prima + 2.4d;
            }else if(edad > 45 )
            {
                prima = prima + 3.2d;
            }

            if(Cliente.IdSexo == 1)
            {
                prima = prima + 0.8d;
            }else if(Cliente.IdSexo == 2)
            {
                prima = prima + 0.4d;
            }

            if(Anho == DateTime.Today.Year)
            {
                prima = prima + 1.2d;
            }else if(Anho < DateTime.Today.Year && Anho >= DateTime.Today.AddYears(-5).Year)
            {
                prima = prima + 0.8d;
            }else if(Anho < DateTime.Today.AddYears(-5).Year)
            {
                prima = prima + 0.4d;
            }

            return prima;
        }
    }
}
