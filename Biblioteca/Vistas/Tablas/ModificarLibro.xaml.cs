﻿using Biblioteca.Modelo;
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
    public partial class ModificarLibro : ContentPage
    {

        public ModificarLibro()
        {
            InitializeComponent();
            this.BindingContext = new AgregarLibroVM(Navigation);
        }


        public ModificarLibro(MLibros obj)
        {

            InitializeComponent();
            BindingContext = new AgregarLibroVM(obj);


        }
        private void ListViewLibros_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {



            var espseleccionada = e.SelectedItem as MLibros;
        }
    }
}