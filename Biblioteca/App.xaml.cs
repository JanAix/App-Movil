using System;
using Biblioteca.Vistas;
using Biblioteca.Vistas.Inicio;
using Biblioteca.Vistas.MenuPrincipal;
using Biblioteca.Vistas.MenuPrincipal0;
using Biblioteca.Vistas.Tablas;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Biblioteca
{
    public partial class App : Application
    {
        public static MasterDetailPage MasterDet {  get; set; } 
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new PantallaPrincipal());
           var MasterDetailPage= new MenuPrincipal();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
