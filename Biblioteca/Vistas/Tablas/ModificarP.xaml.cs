using System;
using Biblioteca.VistaModelo;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Biblioteca.Modelo;

namespace Biblioteca.Vistas.Tablas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModificarP : ContentPage
    {
        public ModificarP()
        {
            InitializeComponent();
            BindingContext = new AgregarPrestamosVM(Navigation);
        }



        public ModificarP(MPrestamo objprestamos)
        {

            InitializeComponent();
            BindingContext= new AgregarPrestamosVM(objprestamos);


        }
    }
}