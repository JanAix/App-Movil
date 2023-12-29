using Biblioteca.Modelo;
using Biblioteca.VistaModelo;
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
    public partial class Socios : ContentPage
    {
        public Socios()
        {
            InitializeComponent();
           this. BindingContext = new AgregarSocioVM(Navigation);
        }

        public Socios(MSocios cliente)
        {


            InitializeComponent();
            this.BindingContext = new AgregarSocioVM(Navigation, cliente);



        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var _container = BindingContext as AgregarSocioVM;
            ListViewSocios.BeginRefresh();

            if (string.IsNullOrWhiteSpace(e.NewTextValue.ToUpper()))
            {
                ListViewSocios.ItemsSource = _container.socioscollection;
            }
            else
            {
                ListViewSocios.ItemsSource = _container.socioscollection.Where(i => i.Nombre.ToUpper().Contains(e.NewTextValue.ToUpper()));
            }
            ListViewSocios.EndRefresh();

        }




        private  async void ListViewSocios_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new SocioModificar(e.SelectedItem as MSocios));
        }
    }
}