using AgendaContato.Models;
using AgendaContato.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AgendaContato.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContatoView : ContentPage
    {
        public ContatoView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var contatos = new ObservableCollection<ContatoModel>(
                ContatoService.Instance.CarregarDados()
            );
            lvlContato.ItemsSource = contatos;
        }

        private void lvlContato_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            //var teste = e.Item;
            var contatoModel = e.Item as ContatoModel;

            Navigation.PushAsync(new ContatoDetalheView(contatoModel.Id));
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var contatos = new ObservableCollection<ContatoModel>(
                ContatoService.Instance.CarregarDados(e.NewTextValue)
            );
            lvlContato.ItemsSource = contatos;
        }

        void CadastroClicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ContatoDetalheView());
        }
    }
}