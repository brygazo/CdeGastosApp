using System;
using System.Collections.Generic;

namespace CdeGastosApp.Models
{

    public class Ingreso
    {
        public int Id { get; set; }

        public string Descripcion { get; set; }

        public DateTime FechaRegistro { get; set; }

        public string Moneda { get; set; }

        public decimal TipoCambio { get; set; }

        public decimal MontoIngreso { get; set; }

        public EstadoIngreso Estado { get; set; }

        public int CuentaId { get; set; }

        public string UsuarioId { get; set; }

        public virtual ApplicationUser Usuario { get; set; }


        public virtual Cuenta Cuenta { get; set; }

       
    }

    public enum EstadoIngreso
    {
        Guardado = 0,
        Aplicado = 1,
        Anulado = 2
    }
}
