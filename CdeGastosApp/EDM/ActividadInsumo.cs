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
    
    public partial class ActividadInsumo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ActividadInsumo()
        {
            this.DetallesGastos = new HashSet<DetalleGasto>();
        }
    
        public int Id { get; set; }
        public int ActividadId { get; set; }
        public int InsumoId { get; set; }
        public double CantidadPresupuestada { get; set; }
        public decimal CostoPresupuestado { get; set; }
        public double CantidadEjecutada { get; set; }
        public decimal CostoEjecutado { get; set; }
    
        public virtual Actividad Actividad { get; set; }
        public virtual Insumo Insumo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleGasto> DetallesGastos { get; set; }
    }
}
