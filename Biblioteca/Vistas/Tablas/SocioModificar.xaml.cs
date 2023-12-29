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
    public partial class SocioModificar : ContentPage
    {
        //public SocioModificar()
        //{
        //    InitializeComponent();
        //    this.BindingContext = new AgregarSocioVM(Navigation);
        //}

        public SocioModificar(MSocios obj)
        {
            InitializeComponent();
            BindingContext = new AgregarSocioVM(obj);



        }
        private void ListViewSocios_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var espseleccionada = e.SelectedItem as MSocios;
        }
    }
}