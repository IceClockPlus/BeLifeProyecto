//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BeLifeDatos
{
    using System;
    using System.Collections.Generic;
    
    public partial class Vivienda
    {
        public Vivienda()
        {
            this.Contrato = new HashSet<Contrato>();
        }
    
        public int CodigoPostal { get; set; }
        public int Anho { get; set; }
        public string Direccion { get; set; }
        public double ValorInmueble { get; set; }
        public double ValorContenido { get; set; }
        public int IdRegion { get; set; }
        public int IdComuna { get; set; }
    
        public virtual RegionComuna RegionComuna { get; set; }
        public virtual ICollection<Contrato> Contrato { get; set; }
    }
}
