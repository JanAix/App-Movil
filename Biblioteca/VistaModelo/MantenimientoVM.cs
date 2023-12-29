using Biblioteca.Vistas.MenuPrincipal;
using Biblioteca.Vistas.Tablas;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Biblioteca.VistaModelo
{
    public class MantenimientoVM : BaseVistaModelo
    {

        #region Constructor
        public MantenimientoVM(INavigation navigation)
        {
            Navigation = navigation;

            Tablaliboscommand = new Command (async() => await Tabla_libros ());
            Tablasocioscommand= new Command(async  () => await Tablasocios_libros());
            VolverPrincipalcommand = new Command(async () => await VolverA_Menu());
        }


        #endregion


        #region Procesos

        private async Task Tabla_libros()
        {

            await Navigation.PushAsync(new ListaLibros());


        }
        private async Task Tablasocios_libros()
        {

            await Navigation.PushAsync(new Socios());

        }


        private async Task VolverA_Menu()
        {
            await Navigation.PopAsync();
           
          
        }

      

        #endregion`



        #region Comando


        public Command Tablaliboscommand { get; }
        public Command Tablasocioscommand { get; }
        public Command VolverPrincipalcommand { get; set; }

        #endregion
    }
}
