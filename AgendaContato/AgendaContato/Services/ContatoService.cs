using AgendaContato.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using AgendaContato.Interfaces;

namespace AgendaContato.Services
{
    public class ContatoService
    {
        private static ContatoService _instance;
        public static ContatoService Instance => _instance ?? (_instance = new ContatoService());

        private SQLiteConnection _conn;

        private ContatoService()
        {
            _conn = DependencyService.Get<ISQLite>()
                                     .GetConnection();
        }

        public IList<ContatoModel> CarregarDados(string filtro = null)
        {
            if (string.IsNullOrEmpty(filtro))
                return _conn.Table<ContatoModel>().ToList();

            return _conn.Table<ContatoModel>()
                        .Where(c => c.Nome.ToLower().Contains(filtro.ToLower()))
                        .ToList();
        }

        public ContatoModel CarregarPorId(string id)
        {
            return _conn.Find<ContatoModel>(id);
        }

        public void Salvar(ContatoModel contatoModel)
        {
            if (string.IsNullOrEmpty(contatoModel.Id))
                contatoModel.Id = Guid.NewGuid().ToString();

            _conn.InsertOrReplace(contatoModel);
        }

        public void Apagar(ContatoModel contatoModel)
        {
            if (string.IsNullOrEmpty(contatoModel.Id))
                return;

            _conn.Delete<ContatoModel>(contatoModel.Id);
        }
    }
}
