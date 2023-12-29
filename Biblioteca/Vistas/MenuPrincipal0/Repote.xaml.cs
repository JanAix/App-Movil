using Biblioteca.Modelo;
using Biblioteca.VistaModelo;
using Biblioteca.Vistas.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Biblioteca.Vistas.MenuPrincipal0
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Repote : ContentPage
    {
        public Repote()
        {
            InitializeComponent();
            BindingContext = new AgregarPrestamosVM(Navigation);
        }


        public Repote (MPrestamo cliente)
        {

            InitializeComponent();
            BindingContext = new AgregarPrestamosVM(Navigation, cliente);

        }

     private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
       {
            var _container = BindingContext as AgregarPrestamosVM;
            ListViewPrestamos.BeginRefresh();

            if (string.IsNullOrWhiteSpace(e.NewTextValue.ToUpper()))
            {
                ListViewPrestamos.ItemsSource = _container.Coleccionprestamos;
            }
            else
            {
                ListViewPrestamos.ItemsSource = _container.Coleccionprestamos.Where(i => i.ID_prestamo.ToUpper().Contains(e.NewTextValue.ToUpper()));
            }
            ListViewPrestamos.EndRefresh();


        }

        private async void ListViewPrestamos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
       {
            await Navigation.PushAsync(new ModificarP(e.SelectedItem as MPrestamo));
        }
    }
}