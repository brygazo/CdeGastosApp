using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace CdeGastosAndroidApp.Activities
{
    [Activity(Label = "RegistrarUsuarioActivity")]
    public class RegistrarUsuarioActivity : Activity
    {
        TextView lblMensaje;
        EditText txtNombres;
        EditText txtApellidos;
        EditText txtNombreUsuario;
        EditText txtEmail;
        EditText txtContrasenia;
        EditText txtConfirmarContrasenia;
        Button btnRegistrarUsuario;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.RegistrarUsuario);


            lblMensaje = FindViewById<TextView>(Resource.Id.lblMensaje);
            txtNombres = FindViewById<EditText>(Resource.Id.txtNombres);
            txtApellidos = FindViewById<EditText>(Resource.Id.txtApellidos);
            txtNombres = FindViewById<EditText>(Resource.Id.txtNombres);
            txtNombreUsuario = FindViewById<EditText>(Resource.Id.txtNombreUsuario);
            txtEmail = FindViewById<EditText>(Resource.Id.txtEmail);
            txtContrasenia = FindViewById<EditText>(Resource.Id.txtContrasenia);
            txtConfirmarContrasenia = FindViewById<EditText>(Resource.Id.txtConfirmarContrasenia);
            btnRegistrarUsuario = FindViewById<Button>(Resource.Id.btnIniciarSesion);

            btnRegistrarUsuario.Click += BtnRegistrarUsuario_Click;
        }

        private void BtnRegistrarUsuario_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}