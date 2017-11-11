using System;
using System.Collections.Generic;


namespace CdeGastosApp.Models
{
    
    public class Actividad
    {
    
        public int Id { get; set; }
        public int PresupuestoId { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
    
        public virtual Presupuesto Presupuesto { get; set; }

        public virtual ICollection<ActividadInsumo> ActividadInsumos { get; set; }
    }
}
