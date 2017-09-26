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

        public ICommand SalvarCommand { get; private set; }

        public ContatoDetalheViewModel(string id)
        {
            ContatoModel = ContatoService.Instance.CarregarPorId(id);
            SalvarCommand = new Command(Salvar);
        }

        private void Salvar()
        {
            ContatoService.Instance.Salvar(ContatoModel);
            Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
