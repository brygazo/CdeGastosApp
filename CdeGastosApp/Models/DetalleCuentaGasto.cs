using System;
using System.Collections.Generic;

namespace CdeGastosApp.Models
{
    public partial class DetalleCuentaGasto
    {
        public int Id { get; set; }
        public int CuentaId { get; set; }
        public int GastoId { get; set; }
        public decimal MontoGasto { get; set; }
    
        public virtual Cuenta Cuenta { get; set; }

        public virtual Gasto Gasto { get; set; }
    }
}
