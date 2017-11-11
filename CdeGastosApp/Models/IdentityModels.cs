using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CdeGastosApp.Models
{
    // Puede agregar datos del perfil del usuario agregando más propiedades a la clase ApplicationUser. Para más información, visite http://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        //Propiedades Extras
        public string Nombres { get; set; }

        public string Apellidos { get; set; }

        public virtual ICollection<Presupuesto> Presupuestos { get; set; }

        public virtual ICollection<Ingreso> Ingresos { get; set; }



        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }


        public virtual DbSet<Actividad> Actividades { get; set; }
        public virtual DbSet<ActividadInsumo> ActividadesInsumos { get; set; }
        public virtual DbSet<CategoriaGasto> CategoriasGastos { get; set; }
        public virtual DbSet<Cuenta> Cuentas { get; set; }
        public virtual DbSet<DetalleCuentaGasto> DetallesCuentasGastos { get; set; }
        public virtual DbSet<DetalleGasto> DetallesGastos { get; set; }
        public virtual DbSet<Gasto> Gastos { get; set; }
        public virtual DbSet<Ingreso> Ingresos { get; set; }
        public virtual DbSet<Insumo> Insumos { get; set; }
        public virtual DbSet<Moneda> Monedas { get; set; }
        public virtual DbSet<Presupuesto> Presupuestos { get; set; }
        public virtual DbSet<TipoCambio> TiposCambios { get; set; }
        public virtual DbSet<TipoInsumo> TiposInsumos { get; set; }
        public virtual DbSet<TipoPresupuesto> TiposPresupuestos { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //Configurando Tabla Usuarios
            modelBuilder.Entity<ApplicationUser>().ToTable("Usuarios").Property(p => p.Email).HasColumnName("CorreoElectronico");
            modelBuilder.Entity<ApplicationUser>().ToTable("Usuarios").Property(p => p.EmailConfirmed).HasColumnName("CorreoElectronicoConfirmado");
            modelBuilder.Entity<ApplicationUser>().ToTable("Usuarios").Property(p => p.PhoneNumber).HasColumnName("NumeroTelefonico");
            modelBuilder.Entity<ApplicationUser>().ToTable("Usuarios").Property(p => p.PhoneNumberConfirmed).HasColumnName("NumeroTelefonicoConfirmado");
            modelBuilder.Entity<ApplicationUser>().ToTable("Usuarios").Property(p => p.UserName).HasColumnName("NombreUsuario");

            //Configurando Tabla Roles
            modelBuilder.Entity<IdentityRole>().ToTable("Roles").Property(p => p.Name).HasColumnName("Descripcion");

            //Configurando Tabla UsuariosRoles
            modelBuilder.Entity<IdentityUserRole>().ToTable("UsuariosRoles")
                                                   .Property(p => p.UserId).HasColumnName("UsuarioId");

            modelBuilder.Entity<IdentityUserRole>().ToTable("UsuariosRoles")
                                                   .Property(p => p.RoleId).HasColumnName("RolId");

            //Configurando Tabla ReclamosUsuarios
            modelBuilder.Entity<IdentityUserClaim>().ToTable("ReclamosUsuarios").Property(p => p.UserId).HasColumnName("UsuarioId");

            //Configurando Tabla LoginsUsuarios
            modelBuilder.Entity<IdentityUserLogin>().ToTable("LoginsUsuarios").Property(p => p.UserId).HasColumnName("UsuarioId");



            modelBuilder.Entity<TipoCambio>().ToTable("TiposCambios");
            modelBuilder.Entity<Moneda>().ToTable("Monedas");
            modelBuilder.Entity<TipoPresupuesto>().ToTable("TiposPresupuestos");
            modelBuilder.Entity<Presupuesto>().ToTable("Presupuestos");
            modelBuilder.Entity<Actividad>().ToTable("Actividades");
            modelBuilder.Entity<ActividadInsumo>().ToTable("ActividadesInsumos");
            modelBuilder.Entity<Insumo>().ToTable("Insumos");
            modelBuilder.Entity<TipoInsumo>().ToTable("TiposInsumos");
            modelBuilder.Entity<DetalleGasto>().ToTable("DetallesGastos");
            modelBuilder.Entity<Gasto>().ToTable("Gastos");
            modelBuilder.Entity<CategoriaGasto>().ToTable("CategoriasGastos");
            modelBuilder.Entity<DetalleCuentaGasto>().ToTable("DetallesCuentasGastos");
            modelBuilder.Entity<Cuenta>().ToTable("Cuentas");
            modelBuilder.Entity<Ingreso>().ToTable("Ingresos");

        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}