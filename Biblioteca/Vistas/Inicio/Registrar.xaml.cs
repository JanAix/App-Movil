using Biblioteca.Conexion;
using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Biblioteca.Vistas.Inicio
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registrar : ContentPage
    {
        public Registrar()
        {
            InitializeComponent();
        }

        private void TapLabelTerminosCondiciones_Tapped(object sender, EventArgs e)
        {
            popupTerminosCondiciones.IsVisible = true;
        }

        private void btnCerrarModal_Clicked(object sender, EventArgs e)
        {
            popupTerminosCondiciones.IsVisible = false;
        }

        private async void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            string email = txtemail.Text;
            string clave = txtclave.Text;

            #region Reglas para la insercion de la información

            if (chkAceptaTerminos.IsChecked != true)
            {
                await DisplayAlert("Alerta", "Seleccione los terminos y condiciones", "Ok");
                return;
            }

            if (string.IsNullOrEmpty(email))
            {
                await DisplayAlert("Alerta", "Escriba su email", "Ok");
                return;
            }

            if (string.IsNullOrEmpty(clave))
            {
                await DisplayAlert("Alerta", "Escriba su contraseña", "Ok");
                return;
            }
            #endregion

            #region Logica para crear el usuario

            await Task.Delay(5);
            var Autentication = new FirebaseAuthProvider(new FirebaseConfig(FireBaseConnection.WepApyAuthentication));
            await Autentication.CreateUserWithEmailAndPasswordAsync(email, clave);
            await App.Current.MainPage.DisplayAlert("Informacion", "Usuario registrado exitosamente.", "Aceptar");
            await App.Current.MainPage.Navigation.PushModalAsync(new Login());

            #endregion

        }
    }
}