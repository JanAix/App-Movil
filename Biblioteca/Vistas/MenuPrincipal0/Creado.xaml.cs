using System;
using Biblioteca.Vistas.MenuPrincipal0;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Biblioteca.Vistas.MenuPrincipal0
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Creado : ContentPage
    {
        public Creado()
        {
            InitializeComponent();
        }


        private void Jan_Tapped_1(object sender, EventArgs e)
        {
            popupJanAlix.IsVisible = true;
        }

        private void btnCerrarModal_Clicked(object sender, EventArgs e)
        {
            popupJanAlix.IsVisible = false;
        }

       
    }
}