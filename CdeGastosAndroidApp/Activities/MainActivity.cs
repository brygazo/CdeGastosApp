using Android.App;
using Android.Widget;
using Android.OS;

namespace CdeGastosAndroidApp
{
    [Activity(Label = "CdeGastos", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        public CdeGastoslocalhost.CdeGastosServicios ws = new CdeGastoslocalhost.CdeGastosServicios();

        TextView lblMensaje;
        EditText txtUsuario;
        EditText txtContrasenia;
        Button btnIniciarSesion;
        TextView lblRegistrarse;

        public MainActivity()
        {
            ws.Url = "http://192.168.1.229/CdeGastos/ServiciosWeb/CdeGastosServicios.asmx";
        }

        protected override void OnCreate(Bundle bundle)
        {

            base.OnCreate(bundle);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            try
            {
                lblMensaje = FindViewById<TextView>(Resource.Id.lblMensaje);
                txtUsuario = FindViewById<EditText>(Resource.Id.txtUsuario);
                txtContrasenia = FindViewById<EditText>(Resource.Id.txtContrasenia);
                lblRegistrarse = FindViewById<TextView>(Resource.Id.lblRegistrarUsuario);
                lblRegistrarse.Click += LblRegistrarse_Click;

                btnIniciarSesion = FindViewById<Button>(Resource.Id.btnIniciarSesion);
                btnIniciarSesion.Click += BtnIniciarSesion_Click;
            }
            catch (System.Exception ex)
            {
                MostrarMensaje("Ha ocurrido un error: " + ex.Message);
            }
            

        }

        private void LblRegistrarse_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void BtnIniciarSesion_Click(object sender, System.EventArgs e)
        {
            try
            {
                ws.IniciarSesionCompleted += Ws_IniciarSesionCompleted;
                ws.IniciarSesionAsync(txtUsuario.Text, txtContrasenia.Text);
                lblMensaje.Text = "Verificando datos...";
                btnIniciarSesion.Enabled = false;
            }
            catch (System.Exception ex)
            {
                MostrarMensaje("Ha ocurrido un error: " + ex.Message);
            }

        }

        private void Ws_IniciarSesionCompleted(object sender, CdeGastoslocalhost.IniciarSesionCompletedEventArgs e)
        {
            btnIniciarSesion.Enabled = true;

            if (e.Result == null)
            {
                MostrarMensaje("Inicio de sesion no valido");
                lblMensaje.Text = "Los datos de inicio de sesion no son validos";
                return;
            }

            MostrarMensaje("Hola, bienvenido a CdeGastos " + e.Result.Nombres + " " + e.Result.Apellidos);
            lblMensaje.Text = "Inicio de sesion satisfactorio Señor " + e.Result.Nombres;

        }

        public void MostrarMensaje(string msj)
        {
            Toast.MakeText(this, msj, ToastLength.Short).Show();
        }
    }
}

