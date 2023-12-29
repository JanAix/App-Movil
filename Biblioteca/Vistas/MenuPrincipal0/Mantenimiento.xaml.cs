using Biblioteca.VistaModelo;
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
	public partial class Matenimiento : ContentPage
	{
		public Matenimiento ()
		{
			InitializeComponent ();
			BindingContext= new MantenimientoVM (Navigation);
		}
	}
}