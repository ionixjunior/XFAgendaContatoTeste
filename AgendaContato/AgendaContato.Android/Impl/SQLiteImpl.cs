using System;
using System.IO;
using AgendaContato.Droid.Impl;
using AgendaContato.Interfaces;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteImpl))]
namespace AgendaContato.Droid.Impl
{
    public class SQLiteImpl : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
			var nomeArquivo = "banco_agenda.db";
			var diretorioPessoal = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			var arquivoBanco = Path.Combine(diretorioPessoal, nomeArquivo);

            return new SQLiteConnection(arquivoBanco);
        }
    }
}
