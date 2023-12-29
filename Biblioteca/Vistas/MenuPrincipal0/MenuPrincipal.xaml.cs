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
	public partial class MenuPrincipal : MasterDetailPage
	{
		public MenuPrincipal()
		{
            InitializeComponent();
            BindingContext = new Master();
		}



		public MenuPrincipal(string v)
		{
			InitializeComponent();
			this.Master = new Master();
			this.Detail = new NavigationPage(new Detail());
			App.MasterDet = this;
		}

      

    }
}