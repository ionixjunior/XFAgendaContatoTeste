using AgendaContato.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaContato.Services
{
    public class ContatoService
    {
        private static ContatoService _instance;
        public static ContatoService Instance => _instance ?? (_instance = new ContatoService());

        private IList<ContatoModel> _contatos;

        private ContatoService()
        {
            _contatos = new List<ContatoModel>();

            for (int i = 1; i <= 20; i++)
            {
                _contatos.Add(new ContatoModel()
                {
                    Id = Guid.NewGuid().ToString(),
                    Nome = $"João {i}",
                    Profissao = $"Programador {i}",
                    Cidade = "Blumenau"
                });
            }
        }

        public IList<ContatoModel> CarregarDados(string filtro = null)
        {
            if (string.IsNullOrEmpty(filtro))
                return _contatos;

            return _contatos.Where(c => c.Nome.ToLower().Contains(filtro.ToLower())).ToList();
        }

        public ContatoModel CarregarPorId(string id)
        {
            return _contatos.Where(c => c.Id == id).FirstOrDefault();
        }

        public void Salvar(ContatoModel contatoModel)
        {
            if (string.IsNullOrEmpty(contatoModel.Id))
            {
                // cadastro
                return;
            }

            var contatoGravado = CarregarPorId(contatoModel.Id);
            var indice = _contatos.IndexOf(contatoGravado);
            _contatos[indice] = contatoModel;
        }
    }
}
