using System;
using System.Collections.Generic;

namespace CdeGastosApp.Models
{   
    public class Cuenta
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; }
    

        public virtual ICollection<Ingreso> Ingresos { get; set; }

        public virtual ICollection<DetalleCuentaGasto> DetallesCuentaGasto { get; set; }
    }
}
