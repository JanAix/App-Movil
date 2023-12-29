using System;
using System.Collections.Generic;
using Biblioteca.VistaModelo;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Biblioteca.Modelo;

namespace Biblioteca.Vistas.Tablas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgregarP : ContentPage
    {
        public AgregarP()
        {
            InitializeComponent();
            BindingContext = new AgregarPrestamosVM(Navigation);
        }



        public AgregarP(MPrestamo objPrestamos)
        {
            InitializeComponent();
            BindingContext = new AgregarPrestamosVM(Navigation, objPrestamos);


        }

        private void ListViewPrestamos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var espseleccionada = e.SelectedItem as MPrestamo;
        }
    }
}