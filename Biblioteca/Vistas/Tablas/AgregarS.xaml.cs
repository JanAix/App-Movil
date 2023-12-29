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
    public partial class AgregarS : ContentPage
    {
        public AgregarS()
        {
            InitializeComponent();
            this.BindingContext =new  AgregarSocioVM(Navigation);
        }
    }
}
