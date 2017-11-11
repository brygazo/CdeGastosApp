using System;
using System.Collections.Generic;

namespace CdeGastosApp.Models
{
    public class DetalleGasto
    {
        public int Id { get; set; }

        public int GastoId { get; set; }

        public int ActividadInsumoId { get; set; }

        public double CantidadGasto { get; set; }

        public decimal CostoGasto { get; set; }
    
        public virtual Gasto Gasto { get; set; }

        public virtual ActividadInsumo ActividadInsumo { get; set; }
    }
}
