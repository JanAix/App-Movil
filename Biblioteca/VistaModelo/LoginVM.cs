using Biblioteca.Conexion;
using Biblioteca.Modelo;
using Biblioteca.Vistas.Inicio;
using Biblioteca.Vistas.MenuPrincipal;
using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Biblioteca.VistaModelo
{
    public class LoginVM : BaseVistaModelo
    {

        #region Atributos
        private string email;
        private string clave;

        #endregion

        #region Propiedades
        public string txtemail
        {
            get { return email; }
            set => SetValue(ref email, value);
        }
        public string txtclave
        {
            get { return clave; }
            set { SetValue(ref clave, value); }
        }

       

        #endregion

        #region Command
        public Command Accesocommand { get; }
       
        
        #endregion

        #region Metodo
        public async Task LoginUsuario()
        {
            if (string.IsNullOrEmpty(txtemail))
            {
               await DisplayAlert("Alerta", "Escriba su email", "Ok");
                return;
            }

            if (string.IsNullOrEmpty(txtclave))
            {
                await DisplayAlert("Alerta", "Escriba su contraseña", "Ok");
                return;
            }


            var objusuario = new UsuarioM()
            {
                Email = email.Trim(),
                Clave = clave
            };
            try
            {

                var autenticacion = new FirebaseAuthProvider(new FirebaseConfig(FireBaseConnection.WepApyAuthentication));
                var authuser = await autenticacion.SignInWithEmailAndPasswordAsync(objusuario.Email.ToString(), objusuario.Clave.ToString());
                string obternertoken = authuser.FirebaseToken;
                MenuPrincipal principal = new MenuPrincipal(objusuario.Email.ToString());
               // Detail principal = new Detail(objusuario.Email.ToString());
                var Propiedades_NavigationPage = new NavigationPage(new MenuPrincipal( objusuario.Email.ToString()));


               ;
                Propiedades_NavigationPage.BarBackgroundColor = Color.RoyalBlue;
                App.Current.MainPage = Propiedades_NavigationPage;
               
            }
            catch (Exception)
            {
               
                await App.Current.MainPage.DisplayAlert("Advertencia", "Las credenciales introducidas son incorrectos o el usuario se encuentra inactivo.", "Aceptar");
            }
            #endregion

           
        }

      


        #region Constructor
        
         public LoginVM(INavigation navegar)
        {
            Navigation = navegar;
            Accesocommand = new Command(async () => await LoginUsuario());
        }
        #endregion
    }

}
    

