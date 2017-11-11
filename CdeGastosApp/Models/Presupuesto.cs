using System;
using System.Collections.Generic;

namespace CdeGastosApp.Models
{
    public class Presupuesto
    {
        public int Id { get; set; }

        public string Codigo { get; set; }

        public string Descripcion { get; set; }

        public DateTime FechaHoraCreacion { get; set; }

        public string Moneda { get; set; }

        public decimal TipoCambio { get; set; }

        public decimal TotalPresupuesto { get; set; }

        public EstadoPresupuesto Estado { get; set; }

        public string UsuarioId { get; set; }

        public virtual ApplicationUser Usuario { get; set; }

        public virtual ICollection<Actividad> Actividades { get; set; }

    }

    public enum EstadoPresupuesto
    {
        Guardado = 0,
        Abierto = 1,
        Cerrado = 2
    }
}
