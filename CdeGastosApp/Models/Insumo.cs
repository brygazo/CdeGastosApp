using System;
using System.Collections.Generic;

namespace CdeGastosApp.Models
{
    public class Insumo
    {

        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public int TipoInsumoId { get; set; }
    
        
        public virtual ICollection<ActividadInsumo> ActividadesInsumo { get; set; }
        public virtual TipoInsumo TipoInsumo { get; set; }
    }
}
