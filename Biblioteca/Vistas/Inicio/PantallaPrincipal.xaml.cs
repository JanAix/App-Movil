using Biblioteca.VistaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Biblioteca.Vistas.Inicio
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PantallaPrincipal : ContentPage
    {
        public PantallaPrincipal()
        {
            InitializeComponent();
            BindingContext = new PantallaInicioVM (Navigation);
        }

       
    }
}