using System;
using System.Collections.Generic;

namespace CdeGastosApp.Models
{    
    public class ActividadInsumo
    {
        public int Id { get; set; }

        public int ActividadId { get; set; }

        public int InsumoId { get; set; }

        public double CantidadPresupuestada { get; set; }

        public decimal CostoPresupuestado { get; set; }

        public double CantidadEjecutada { get; set; }

        public decimal CostoEjecutado { get; set; }
    
        public virtual Actividad Actividad { get; set; }

        public virtual Insumo Insumo { get; set; }
        
        public virtual ICollection<DetalleGasto> DetallesGastos { get; set; }
    }
}
