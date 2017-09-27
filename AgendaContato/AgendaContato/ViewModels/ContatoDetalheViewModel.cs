using AgendaContato.Models;
using AgendaContato.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Plugin.Geolocator;

namespace AgendaContato.ViewModels
{
    public class ContatoDetalheViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ContatoModel _contatoModel;
        public ContatoModel ContatoModel
        {
            get => _contatoModel;
            set
            {
                _contatoModel = value;
                OnPropertyChanged();
            }
        }

        private string _resultadoGPS;
        public string ResultadoGPS
        {
            get => _resultadoGPS;
            set
            {
                _resultadoGPS = value;
                OnPropertyChanged();
            }
        }

        public ICommand SalvarCommand { get; private set; }
        public ICommand ApagarCommand { get; private set; }
        public ICommand CarregarLocalizacaoCommand { get;  private set; }

        public ContatoDetalheViewModel(string id = null)
        {
            if (id == null)
            {
                ContatoModel = new ContatoModel();
            }
            else
            {
                ContatoModel = ContatoService.Instance.CarregarPorId(id);
            }

            SalvarCommand = new Command(Salvar);
            ApagarCommand = new Command(Apagar);
            CarregarLocalizacaoCommand = new Command(async () => await CarregarLocalizacao());
        }

        private void Salvar()
        {
            ContatoService.Instance.Salvar(ContatoModel);
            Application.Current.MainPage.Navigation.PopAsync();
        }

        private void Apagar()
        {
			ContatoService.Instance.Apagar(ContatoModel);
			Application.Current.MainPage.Navigation.PopAsync();
        }

        private async Task CarregarLocalizacao()
        {
            try
            {
				var locator = CrossGeolocator.Current;
				locator.DesiredAccuracy = 50;
                var position = await locator.GetPositionAsync(10000);

                ContatoModel.Latitude = position.Latitude;
                ContatoModel.Longitude = position.Longitude;

                ResultadoGPS = "Posição do GPS carregada com sucesso!";
            }
            catch (Exception e)
            {
                ResultadoGPS = "Não foi possível carregar a informação do GPS";
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
		}
    }
}
