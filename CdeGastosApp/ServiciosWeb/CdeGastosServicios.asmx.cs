using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using CdeGastosApp.DAL;
using CdeGastosApp.Models;
using CdeGastosApp.DTO;

namespace CdeGastosApp.ServiciosWeb
{
    /// <summary>
    /// Descripción breve de CdeGastosServicios
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class CdeGastosServicios : System.Web.Services.WebService
    {

        private WebServiceDAL wsDAL = new WebServiceDAL();

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos putos retrasados, yo funciono no joda!";
        }

        [WebMethod]
        public UsuarioDTO IniciarSesion(string usuario, string contrasenia)
        {
            return wsDAL.IniciarSesion(usuario, contrasenia);
        }

        [WebMethod]
        public string RegistrarUsuario(string nombres, string apellidos, string nombreUsuario, string email, string contrasenia)
        {
            return wsDAL.RegistrarUsuario(nombres, apellidos, nombreUsuario, email, contrasenia);
        }

        //[WebMethod]
        //public string RegistrarUsuario(RegisterViewModel datosRegistros)
        //{
        //    return wsDAL.RegistrarUsuario(datosRegistros);
        //}

        #region TipoInsumo

        [WebMethod]
        public string CrearTipoInsumo(TipoInsumoDTO TipoInsumo)
        {
            return wsDAL.CrearTipoInsumo(TipoInsumo);
        }

        #endregion
    }
}
