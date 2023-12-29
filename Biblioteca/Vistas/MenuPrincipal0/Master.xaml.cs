using Biblioteca.Modelo;
using Biblioteca.VistaModelo;
using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Biblioteca.Vistas.MenuPrincipal
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Master : ContentPage
	{
      
        public Master()
		{
			InitializeComponent();
			BindingContext = new MasterVM(Navigation);
		}

		
       

       


    } 
}