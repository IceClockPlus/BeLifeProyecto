using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelifeLibrary
{
    public class Contrato
    {
        private BeLifeDatos.BeLifeEntities bbdd = new BeLifeDatos.BeLifeEntities();
        private DateTime _inicioVigencia { get; set; }
        /// <summary>
        /// Numero de contrato, es generado automáticamente dependiendo la fecha y la hora
        /// de generación del contrato.
        /// </summary>
        public string Numero { get; set; }

        /// <summary>
        /// Fecha de creación. Generada automáticamente al crear el contrato.
        /// </summary>
        public DateTime FechaCreacion { get; set; }

        /// <summary>
        /// Fecha de Termino. Generada automáticamente, justo un año después de la fecha de creación.
        /// </summary>
        public DateTime Termino { get; set; }

        /// <summary>
        /// Propiedad que hereda un objeto de tipo cliente.
        /// Su rut se almacena como titular del contrato.
        /// </summary>
        public Cliente Titular { get; set; }

        /// <summary>
        /// Propiedad que hereda un plan pre definido.
        /// Según el ID del plan, se accesará a sus distintos atributos.
        /// </summary>
        public Plan PlanAsociado { get; set; }

        /// <summary>
        /// Propiedad heredada del PlanAsociado, según el Id del plan.
        /// </summary>
        public string Poliza { get; set; }


        /// <summary>
        /// Fecha Inicio Vigencia del contrato.
        /// Esta no puede ser menor a la fecha actual ni puede exceder de 1 mes.
        /// </summary>
        public DateTime FechaInicioVigencia {
            get { return _inicioVigencia; }
            set
            {
                if (Negocio.Configuracion.ValidarFechaInicioContrato(value))
                    _inicioVigencia = value;
                else
                    throw new Exception("Fecha de inicio de contrato invalida. Verificar que no sea menor a la fecha actual ni la exceda 1 mes.");
            }
        }


        public DateTime FechaFinVigencia { get; set; }

        /// <summary>
        /// Si la fecha de FinVigencia aún no llega, el contrato está vigente.
        /// </summary>
        public bool EstaVigente { get; set; }


        public bool ConDeclaracionDeSalud { get; set; }

        /// <summary>
        /// Es generada automáticamente según la prima Mensual
        /// </summary>
        public float PrimaAnual { get; set; }

        /// <summary>
        /// Se genera a través de una PrimaBase por plan.
        /// Se modifica según los atributos del cliente (Edad, Sexo, Estado Civil)
        /// </summary>
        public float PrimaMensual { get; set; }

        /// <summary>
        /// Observaciones extras del contrato.
        /// Asignadas por el usuario del sistema.
        /// </summary>
        public string Observaciones { get; set; }


        public int IdTipoContrato { get; set; }

        /// <summary>
        /// Inicializamos una instancia contrato, para luego ingresarlo a la base de datos.
        /// </summary>
        public Contrato()
        {
            this.Init();
        }


        /// <summary>
        /// Inicializamos por defecto los atributos del nuevo contrato.
        /// </summary>
        private void Init()
        {
            Numero = Negocio.Configuracion.CrearNumeroContrato();
            FechaCreacion = DateTime.Today;
            Termino = Negocio.Configuracion.CrearFechaTermino();
            Titular = new Cliente();
            PlanAsociado = new Plan();
            Poliza = string.Empty;
            _inicioVigencia = new DateTime();
            FechaFinVigencia = new DateTime();
            EstaVigente = false;
            ConDeclaracionDeSalud = false;
            PrimaAnual = 0f;
            PrimaMensual = 0f;
            Observaciones = string.Empty;
            IdTipoContrato = 0;

        }

        /// <summary>
        /// Creamos el nuevo contrato dentro de la base de datos.
        /// Verifica que el contrato no exista, según su numero de contrato.
        /// </summary>
        /// <returns></returns>
        public bool Create()
        {
            try
            {
                /* Intenta buscar el ccontrato asociado al numero de contrato que se desea agregar.*/
                var contrato = bbdd.Contrato.Where(x => x.Numero == Numero).SingleOrDefault();
                if (contrato != null)
                {
                    /* En caso de que lo encuentre, levanta una excepción */
                     throw new Exception("Error! Ya existe un contrato con ese numero.");
                }
                /* No se encontró el numero del contrato, por lo que el contrato no existe.*/
                else
                {
                    /* Agregamos el contrato*/
                    BeLifeDatos.Contrato con = new BeLifeDatos.Contrato();

                    con.RutCliente = this.Titular.Rut;
                    con.CodigoPlan = this.PlanAsociado.Id;
                    con.Cliente = bbdd.Cliente.FirstOrDefault(r => r.Rut == this.Titular.Rut);
                    con.Plan = bbdd.Plan.FirstOrDefault(p => p.Id == this.PlanAsociado.Id);
                    con.FechaCreacion = this.FechaCreacion;
                    con.FechaInicioVigencia = this.FechaInicioVigencia;
                    con.FechaFinVigencia = this.FechaFinVigencia;
                    CommonBC.Syncronize(this, con);

                    bbdd.Contrato.Add(con);
                    bbdd.SaveChanges();
                    return true;
                }
            }

            catch (Exception ex)
            {
                /* En caso de encontrar alguna excepción, la imprime en consola y se la envía al WPF para controlar el mensaje*/
                 Console.Write(ex.InnerException);
                return false;
            }
        }

        public Contrato Read() {
            try
            {
                /*Busca cliente con el rut entregado*/
                var contrato = bbdd.Contrato.Where(x => x.Numero == Numero).SingleOrDefault();

                /*Si el cliente es distinto a null, significa que se encontró, por lo que creamos un nuevo cliente de la
                 librería de clases para retornar.*/
                if (contrato != null)
                {
                    CommonBC.Syncronize(contrato, this);
                    return this;
                }
                else
                    throw new Exception("Error! No se ha podido encontrar el contrato con el numero asociado.");



            }
            catch (Exception ex)
            {
                /*En caso de encontrar alguna excepción, la imprime en consola y se la envía al WPF para controlar el mensaje*/
                Console.Write(ex);
                throw ex;
            }
        }

        public bool Update() {
            try
            {
                /*Busca contrato con el numero entregado*/
                var contrato = bbdd.Contrato.Where(x => x.Numero == Numero).SingleOrDefault();
                if (contrato != null)
                {
                    /*En caso de que el contrato no sea null, es decir, que lo haya encontrado, lo actualizamos y guardamos cambios.*/
                    CommonBC.Syncronize(this, contrato);
                    bbdd.SaveChanges();
                    return true;
                }
                else
                {
                    /*En caso de no encontrar un contrato con el numero asociado, enviamos una excepción*/
                    throw new Exception();
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

        public bool Delete() {
            try
            {
                /*Buscamos un contrato al rut*/
                var contrato = bbdd.Contrato.Where(x => x.Numero == Numero).SingleOrDefault();
                /*Si lo encuentra lo elimina*/
                if (contrato != null)
                {
                    this.Termino = DateTime.Now;
                    this.FechaFinVigencia = DateTime.Now;
                    this.EstaVigente = false;
                    CommonBC.Syncronize(this, contrato);
                    bbdd.SaveChanges();
                    return true;
                }
                else
                {
                    /*Si no lo encuentra, levanta una excepción.*/
                    throw new Exception("Error! No se ha encontrado un numero que coinicida con algún contrato");
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
        /// Buscamos todos los contratos de la base de datos y los convertimos a entidades
        /// </summary>
        /// <returns></returns>
        public List<Contrato> ReadAll()
        {
            /*Creamos una lista de contratos del contexto*/
            List<BeLifeDatos.Contrato> listaDatos = bbdd.Contrato.ToList<BeLifeDatos.Contrato>();

            /*Los convertimos a Contratos legibles*/
            List<Contrato> list = SyncList(listaDatos);

            /*Devolvemos la lista*/
            return list;
        }

        /// <summary>
        /// Buscamos todos los contratos de la base de datos que coincidan con el numero de contrato y los convertimos a entidades
        /// </summary>
        /// <returns></returns>
        public List<Contrato> ReadAllByNumeroContrato()
        {
            /*Creamos una lista de contratos del contexto*/
            List<BeLifeDatos.Contrato> listaDatos = bbdd.Contrato.Where(x => x.Numero == Numero).ToList();

            /*Los convertimos a Contratos legibles*/
            List<Contrato> list = SyncList(listaDatos);

            /*Devolvemos la lista*/
            return list;
        }

        /// <summary>
        /// Buscamos todos los contratos de la base de datos que coincidan con el rut del titular y los convertimos a entidades
        /// </summary>
        /// <returns></returns>
        public List<Contrato> ReadAllByRut()
        {
            /*Creamos una lista de contratos del contexto*/
            List<BeLifeDatos.Contrato> listaDatos = bbdd.Contrato.Where(x => x.RutCliente == Titular.Rut).ToList();

            /*Los convertimos a Contratos legibles*/
            List<Contrato> list = SyncList(listaDatos);

            /*Devolvemos la lista*/
            return list;
        }

        /// <summary>
        /// Buscamos todos los contratos de la base de datos que coincidan con el rut del titular y los convertimos a entidades
        /// </summary>
        /// <returns></returns>
        public List<Contrato> ReadAllByPoliza()
        {
            /*Creamos una lista de contratos del contexto*/
            List<BeLifeDatos.Contrato> listaDatos = bbdd.Contrato.Where(x => x.Plan.PolizaActual == Poliza).ToList();

            /*Los convertimos a Contratos legibles*/
            List<Contrato> list = SyncList(listaDatos);

            /*Devolvemos la lista*/
            return list;
        }

        /// <summary>
        /// Metodo para convertir una lista de contexto a lista legible por las librerias.
        /// </summary>
        /// <param name="listaDatos"></param>
        /// <returns></returns>
        private static List<Contrato> SyncList(List<BeLifeDatos.Contrato> listaDatos)
        {
            /* Creamos una lista de contratos*/
             List < Contrato > list = new List<Contrato>();
            BeLifeDatos.BeLifeEntities bbdd = new BeLifeDatos.BeLifeEntities();
            /* Por cada elemento de la lista de contratos del contexto realizamos una sincronización y los agregamos a la lista de Contratos*/
            foreach (var x in listaDatos)
            {
                BelifeLibrary.Cliente cliente = new BelifeLibrary.Cliente()
                {
                    Rut = x.RutCliente
                };

                var resultado = cliente.Read(); //Me devuelve el cliente

                BeLifeDatos.Plan planBuscado = bbdd.Plan.Where(p => p.Id == x.Plan.Id).SingleOrDefault(); //Buscar Un plan de la base de datos

                BelifeLibrary.Plan plan = new BelifeLibrary.Plan()
                {
                    Id = planBuscado.Id,
                    Nombre = planBuscado.Nombre,
                    PolizaActual = planBuscado.PolizaActual,
                    PrimaBase = planBuscado.PrimaBase
                };



                Contrato contrato = new Contrato()
                {
                    Numero = x.Numero,
                    Termino = Negocio.Configuracion.CrearFechaTermino(),
                    Titular = resultado,
                    FechaCreacion = x.FechaCreacion,
                    ConDeclaracionDeSalud = x.DeclaracionSalud,
                    EstaVigente = x.Vigente,
                    FechaFinVigencia = x.FechaFinVigencia,
                    FechaInicioVigencia = x.FechaInicioVigencia,
                    Observaciones = x.Observaciones,
                    PlanAsociado = plan,
                    Poliza = plan.PolizaActual,
                    PrimaAnual = (float) x.PrimaAnual,
                    PrimaMensual = (float) x.PrimaMensual
                };

                list.Add(contrato);
            }
            return list;
        }

    }
}
