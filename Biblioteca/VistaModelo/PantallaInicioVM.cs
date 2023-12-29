using Biblioteca.Vistas.Inicio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Biblioteca.VistaModelo
{
    public class PantallaInicioVM: BaseVistaModelo
    {

      
        #region VARIABLES

        #endregion

        #region CONSTRUCTOR
        public PantallaInicioVM(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion

        #region OBJETOS

        #endregion

        #region PROCESOS
        private async void NavegarLogin()
        {

            await Navigation.PushAsync(new Login());
        }

        #endregion

        #region COMANDOS
        public ICommand NavegarLogincommand => new Command(NavegarLogin);
       
        #endregion
    }

}


    
