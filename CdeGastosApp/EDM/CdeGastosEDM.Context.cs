﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CdeGastosApp.EDM
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CdeGastosEDMContainer : DbContext
    {
        public CdeGastosEDMContainer()
            : base("name=CdeGastosEDMContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TipoPresupuesto> TiposPresupuestos { get; set; }
        public virtual DbSet<Presupuesto> Presupuestos { get; set; }
        public virtual DbSet<Moneda> Monedas { get; set; }
        public virtual DbSet<TipoCambio> TiposCambio { get; set; }
        public virtual DbSet<Gasto> Gastos { get; set; }
        public virtual DbSet<CategoriaGasto> CategoriasGastos { get; set; }
        public virtual DbSet<Actividad> Actividades { get; set; }
        public virtual DbSet<Insumo> Insumos { get; set; }
        public virtual DbSet<ActividadInsumo> ActividadesInsumos { get; set; }
        public virtual DbSet<TipoInsumo> TiposInsumos { get; set; }
        public virtual DbSet<DetalleGasto> DetallesGastos { get; set; }
        public virtual DbSet<Ingreso> Ingresos { get; set; }
        public virtual DbSet<Cuenta> Cuentas { get; set; }
        public virtual DbSet<DetalleCuentaGasto> DetallessCuentasGastos { get; set; }
    }
}
