using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Vistas.MenuPrincipal0;
using Biblioteca.VistaModelo;
using Xamarin.Forms;
using System.Data;

namespace Biblioteca.VistaModelo
{
    class MasterVM : BaseVistaModelo
    {

        #region constructor

        public MasterVM() { 
        }   

        public MasterVM(INavigation navigation)
        {
            Navigation = navigation;

            NavegacionMantenimientocommand = new Command(async () => await NavegacionMantenimiento());
            Navegacionreportecommand = new Command(async () => await Navegacionreporte());
            Navegacioncreadocommand = new Command(async () => await Navegacioncreado());
        }

        public MasterVM(INavigation navigation, string usu) 
        {
            Navigation = navigation;

            NavegacionMantenimientocommand = new Command(async () => await NavegacionMantenimiento());
            Navegacionreportecommand = new Command(async () => await Navegacionreporte());
            Navegacioncreadocommand = new Command(async () => await Navegacioncreado());

        }
        #region variable


        #endregion

      


        #endregion


            #region Proceso
        private async Task NavegacionMantenimiento()
        {
            await Navigation.PushAsync(new Matenimiento());


        }
        private async Task Navegacionreporte()
        {


            await Navigation.PushAsync (new Repote());


        }
        private async Task Navegacioncreado()
        {

            await Navigation.PushAsync (new Creado());  

        }


        #endregion


        #region Comando

        public Command NavegacionMantenimientocommand { get; }
        public Command Navegacionreportecommand {  get; }
        public Command Navegacioncreadocommand { get; }
        public string Usuario { get;  }

   


        #endregion
    }
}
