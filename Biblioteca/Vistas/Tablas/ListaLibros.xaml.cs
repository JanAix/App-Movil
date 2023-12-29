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

namespace Biblioteca.Vistas.Tablas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaLibros : ContentPage
    {


        public ListaLibros()
        {
            InitializeComponent();
            BindingContext = new AgregarLibroVM(Navigation);
        }

        public ListaLibros(MLibros cliente)
        {

            InitializeComponent();
            BindingContext = new AgregarLibroVM(Navigation, cliente);

        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var _container = BindingContext as AgregarLibroVM;
            ListViewLibros.BeginRefresh();

            if (string.IsNullOrWhiteSpace(e.NewTextValue.ToUpper()))
            {
                ListViewLibros.ItemsSource = _container.librocollection;
            }
            else
            {
                ListViewLibros.ItemsSource = _container.librocollection.Where(i => i.Libro.ToUpper().Contains(e.NewTextValue.ToUpper()));
            }
            ListViewLibros.EndRefresh();



          
        }

        

        private async void ListViewLibros_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new ModificarLibro(e.SelectedItem as MLibros));
        }
    }

}
    
