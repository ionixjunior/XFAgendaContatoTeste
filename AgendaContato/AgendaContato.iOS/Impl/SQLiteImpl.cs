using System;
using System.IO;
using AgendaContato.Interfaces;
using AgendaContato.iOS.Impl;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteImpl))]
namespace AgendaContato.iOS.Impl
{
    public class SQLiteImpl : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
			var nomeArquivo = "banco_agenda.db";
			var diretorioPessoal = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			var diretorioLibs = Path.Combine(diretorioPessoal, "..", "Library");
			var arquivoBanco = Path.Combine(diretorioLibs, nomeArquivo);

			return new SQLiteConnection(arquivoBanco);
        }
    }
}
