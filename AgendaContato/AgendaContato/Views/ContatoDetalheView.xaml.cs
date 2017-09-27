using AgendaContato.Services;
using AgendaContato.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AgendaContato.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContatoDetalheView : ContentPage
	{
		public ContatoDetalheView (string id = null)
		{
			InitializeComponent ();
            BindingContext = new ContatoDetalheViewModel(id);
		}
	}
}