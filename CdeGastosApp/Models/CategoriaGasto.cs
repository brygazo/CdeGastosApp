using System;
using System.Collections.Generic;

namespace CdeGastosApp.Models
{
    
    public class CategoriaGasto
    {
        public int Id { get; set; }

        public string Codigo { get; set; }

        public string Descripcion { get; set; }

        public int? CategoriaGastoPadreId { get; set; }
    
        public virtual ICollection<CategoriaGasto> CategoriaGastoHijas { get; set; }

        public virtual CategoriaGasto CategoriaGastoPadre { get; set; }

        public virtual ICollection<Gasto> Gastos { get; set; }

    }
}
