//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CdeGastosApp.EDM
{
    using System;
    using System.Collections.Generic;
    
    public partial class Gasto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Gasto()
        {
            this.DetallesGasto = new HashSet<DetalleGasto>();
            this.DetallesCuentasGasto = new HashSet<DetalleCuentaGasto>();
        }
    
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public System.DateTime FechaGasto { get; set; }
        public System.DateTime FechaRegistro { get; set; }
        public int CategoriaGastoId { get; set; }
        public decimal TotalGasto { get; set; }
        public string Moneda { get; set; }
        public decimal TipoCambio { get; set; }
        public int Estado { get; set; }
    
        public virtual CategoriaGasto CategoriaGasto { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleGasto> DetallesGasto { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleCuentaGasto> DetallesCuentasGasto { get; set; }
    }
}
