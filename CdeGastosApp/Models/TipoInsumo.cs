using System;
using System.Collections.Generic;

namespace CdeGastosApp.Models
{
    public class TipoInsumo
    {
            
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
    
        
        public virtual ICollection<Insumo> Insumos { get; set; }
    }
}
