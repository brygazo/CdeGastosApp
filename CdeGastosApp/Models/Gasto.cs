using System;
using System.Collections.Generic;

namespace CdeGastosApp.Models
{
    public class Gasto
    {
        public int Id { get; set; }

        public string Codigo { get; set; }

        public string Descripcion { get; set; }

        public DateTime FechaGasto { get; set; }

        public DateTime FechaRegistro { get; set; }

        public int MyProperty { get; set; }

        public string Moneda { get; set; }

        public decimal TipoCambio { get; set; }


        public decimal TotalGasto { get; set; }

        public EstadoGasto Estado { get; set; }

        public int CategoriaGastoId { get; set; }

        public virtual CategoriaGasto CategoriaGasto { get; set; }
        
        public virtual ICollection<DetalleGasto> DetallesGasto { get; set; }

        public virtual ICollection<DetalleCuentaGasto> DetallesCuentasGasto { get; set; }

    }

    public enum EstadoGasto
    {
        Guardado = 0,
        Aplicado = 1,
        Anulado = 2
    }

}
