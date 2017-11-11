namespace CdeGastosApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inic : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Descripcion = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Descripcion, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.UsuariosRoles",
                c => new
                    {
                        UsuarioId = c.String(nullable: false, maxLength: 128),
                        RolId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UsuarioId, t.RolId })
                .ForeignKey("dbo.Roles", t => t.RolId, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.UsuarioId)
                .Index(t => t.RolId);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Nombres = c.String(),
                        Apellidos = c.String(),
                        CorreoElectronico = c.String(maxLength: 256),
                        CorreoElectronicoConfirmado = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        NumeroTelefonico = c.String(),
                        NumeroTelefonicoConfirmado = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        NombreUsuario = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.NombreUsuario, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.ReclamosUsuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UsuarioId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Ingresos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        FechaRegistro = c.DateTime(nullable: false),
                        Moneda = c.String(),
                        TipoCambio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MontoIngreso = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Estado = c.Int(nullable: false),
                        CuentaId = c.Int(nullable: false),
                        UsuarioId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cuentas", t => t.CuentaId, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId)
                .Index(t => t.CuentaId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Cuentas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.String(),
                        Descripcion = c.String(),
                        FechaRegistro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DetallesCuentasGastos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CuentaId = c.Int(nullable: false),
                        GastoId = c.Int(nullable: false),
                        MontoGasto = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cuentas", t => t.CuentaId, cascadeDelete: true)
                .ForeignKey("dbo.Gastos", t => t.GastoId, cascadeDelete: true)
                .Index(t => t.CuentaId)
                .Index(t => t.GastoId);
            
            CreateTable(
                "dbo.Gastos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.String(),
                        Descripcion = c.String(),
                        FechaGasto = c.DateTime(nullable: false),
                        FechaRegistro = c.DateTime(nullable: false),
                        MyProperty = c.Int(nullable: false),
                        Moneda = c.String(),
                        TipoCambio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalGasto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Estado = c.Int(nullable: false),
                        CategoriaGastoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CategoriasGastos", t => t.CategoriaGastoId, cascadeDelete: true)
                .Index(t => t.CategoriaGastoId);
            
            CreateTable(
                "dbo.CategoriasGastos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.String(),
                        Descripcion = c.String(),
                        CategoriaGastoPadreId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CategoriasGastos", t => t.CategoriaGastoPadreId)
                .Index(t => t.CategoriaGastoPadreId);
            
            CreateTable(
                "dbo.DetallesGastos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GastoId = c.Int(nullable: false),
                        ActividadInsumoId = c.Int(nullable: false),
                        CantidadGasto = c.Double(nullable: false),
                        CostoGasto = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ActividadesInsumos", t => t.ActividadInsumoId, cascadeDelete: true)
                .ForeignKey("dbo.Gastos", t => t.GastoId, cascadeDelete: true)
                .Index(t => t.GastoId)
                .Index(t => t.ActividadInsumoId);
            
            CreateTable(
                "dbo.ActividadesInsumos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ActividadId = c.Int(nullable: false),
                        InsumoId = c.Int(nullable: false),
                        CantidadPresupuestada = c.Double(nullable: false),
                        CostoPresupuestado = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CantidadEjecutada = c.Double(nullable: false),
                        CostoEjecutado = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Actividades", t => t.ActividadId, cascadeDelete: true)
                .ForeignKey("dbo.Insumos", t => t.InsumoId, cascadeDelete: true)
                .Index(t => t.ActividadId)
                .Index(t => t.InsumoId);
            
            CreateTable(
                "dbo.Actividades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PresupuestoId = c.Int(nullable: false),
                        Codigo = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Presupuestos", t => t.PresupuestoId, cascadeDelete: true)
                .Index(t => t.PresupuestoId);
            
            CreateTable(
                "dbo.Presupuestos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.String(),
                        Descripcion = c.String(),
                        FechaHoraCreacion = c.DateTime(nullable: false),
                        Moneda = c.String(),
                        TipoCambio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalPresupuesto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Estado = c.Int(nullable: false),
                        UsuarioId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Insumos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.String(),
                        Descripcion = c.String(),
                        TipoInsumoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TiposInsumos", t => t.TipoInsumoId, cascadeDelete: true)
                .Index(t => t.TipoInsumoId);
            
            CreateTable(
                "dbo.TiposInsumos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LoginsUsuarios",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UsuarioId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UsuarioId })
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.TiposCambios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fecha = c.String(),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Monedas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TiposPresupuestos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsuariosRoles", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.LoginsUsuarios", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.Ingresos", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.Ingresos", "CuentaId", "dbo.Cuentas");
            DropForeignKey("dbo.DetallesGastos", "GastoId", "dbo.Gastos");
            DropForeignKey("dbo.Insumos", "TipoInsumoId", "dbo.TiposInsumos");
            DropForeignKey("dbo.ActividadesInsumos", "InsumoId", "dbo.Insumos");
            DropForeignKey("dbo.DetallesGastos", "ActividadInsumoId", "dbo.ActividadesInsumos");
            DropForeignKey("dbo.Presupuestos", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.Actividades", "PresupuestoId", "dbo.Presupuestos");
            DropForeignKey("dbo.ActividadesInsumos", "ActividadId", "dbo.Actividades");
            DropForeignKey("dbo.DetallesCuentasGastos", "GastoId", "dbo.Gastos");
            DropForeignKey("dbo.Gastos", "CategoriaGastoId", "dbo.CategoriasGastos");
            DropForeignKey("dbo.CategoriasGastos", "CategoriaGastoPadreId", "dbo.CategoriasGastos");
            DropForeignKey("dbo.DetallesCuentasGastos", "CuentaId", "dbo.Cuentas");
            DropForeignKey("dbo.ReclamosUsuarios", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.UsuariosRoles", "RolId", "dbo.Roles");
            DropIndex("dbo.LoginsUsuarios", new[] { "UsuarioId" });
            DropIndex("dbo.Insumos", new[] { "TipoInsumoId" });
            DropIndex("dbo.Presupuestos", new[] { "UsuarioId" });
            DropIndex("dbo.Actividades", new[] { "PresupuestoId" });
            DropIndex("dbo.ActividadesInsumos", new[] { "InsumoId" });
            DropIndex("dbo.ActividadesInsumos", new[] { "ActividadId" });
            DropIndex("dbo.DetallesGastos", new[] { "ActividadInsumoId" });
            DropIndex("dbo.DetallesGastos", new[] { "GastoId" });
            DropIndex("dbo.CategoriasGastos", new[] { "CategoriaGastoPadreId" });
            DropIndex("dbo.Gastos", new[] { "CategoriaGastoId" });
            DropIndex("dbo.DetallesCuentasGastos", new[] { "GastoId" });
            DropIndex("dbo.DetallesCuentasGastos", new[] { "CuentaId" });
            DropIndex("dbo.Ingresos", new[] { "UsuarioId" });
            DropIndex("dbo.Ingresos", new[] { "CuentaId" });
            DropIndex("dbo.ReclamosUsuarios", new[] { "UsuarioId" });
            DropIndex("dbo.Usuarios", "UserNameIndex");
            DropIndex("dbo.UsuariosRoles", new[] { "RolId" });
            DropIndex("dbo.UsuariosRoles", new[] { "UsuarioId" });
            DropIndex("dbo.Roles", "RoleNameIndex");
            DropTable("dbo.TiposPresupuestos");
            DropTable("dbo.Monedas");
            DropTable("dbo.TiposCambios");
            DropTable("dbo.LoginsUsuarios");
            DropTable("dbo.TiposInsumos");
            DropTable("dbo.Insumos");
            DropTable("dbo.Presupuestos");
            DropTable("dbo.Actividades");
            DropTable("dbo.ActividadesInsumos");
            DropTable("dbo.DetallesGastos");
            DropTable("dbo.CategoriasGastos");
            DropTable("dbo.Gastos");
            DropTable("dbo.DetallesCuentasGastos");
            DropTable("dbo.Cuentas");
            DropTable("dbo.Ingresos");
            DropTable("dbo.ReclamosUsuarios");
            DropTable("dbo.Usuarios");
            DropTable("dbo.UsuariosRoles");
            DropTable("dbo.Roles");
        }
    }
}
