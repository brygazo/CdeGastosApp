using CdeGastosApp.DTO;
using CdeGastosApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CdeGastosApp.DAL
{
    public class WebServiceDAL
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public UsuarioDTO IniciarSesion(string Nombreusuario, string contrasenia)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            var u = userManager.Find(Nombreusuario, contrasenia);

            UsuarioDTO usuarioDTO = null;

            if (u != null)
            {
                usuarioDTO = new UsuarioDTO();
                usuarioDTO.Id = u.Id;
                usuarioDTO.Nombres = u.Nombres;
                usuarioDTO.Apellidos = u.Apellidos;
                usuarioDTO.NombreUsuario = u.UserName;
                usuarioDTO.Email = u.Email;
            }

            return usuarioDTO;
        }


        public string RegistrarUsuario(string nombres, string apellidos, string nombreUsuario, string email, string contrasenia)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            var usuario = new ApplicationUser();
            usuario.Nombres = nombres;
            usuario.Apellidos = apellidos;
            usuario.UserName = nombreUsuario;
            usuario.Email = email;

            var resultado = userManager.Create(usuario, contrasenia);

            if (resultado.Succeeded)
                return "¡Su registro se realizo satifactoriamente! Bienvenido a CdeGastos";

            return resultado.Errors.FirstOrDefault();

        }

        public string RegistrarUsuario(RegisterViewModel datosRegistro)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            var usuario = new ApplicationUser();
            usuario.Nombres = datosRegistro.Nombres;
            usuario.Apellidos = datosRegistro.Apellidos;
            usuario.UserName = datosRegistro.NombreUsuario;
            usuario.Email = datosRegistro.Email;

            var resultado = userManager.Create(usuario, datosRegistro.Password);

            if (resultado.Succeeded)
                return "¡Su registro se realizo satifactoriamente! Bienvenido a CdeGastos";

            return resultado.Errors.FirstOrDefault();

        }

        public string CrearTipoInsumo(TipoInsumoDTO TipoInsumo)
        {
            try
            {
                var tipoInsumo = new TipoInsumo()
                {
                    Codigo = TipoInsumo.Codigo,
                    Descripcion = TipoInsumo.Descripcion
                };

                db.TiposInsumos.Add(tipoInsumo);
                db.SaveChanges();

                return "Ok";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }

        }
    }
}