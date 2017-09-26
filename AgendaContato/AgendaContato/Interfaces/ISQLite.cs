using System;
using SQLite;

namespace AgendaContato.Interfaces
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
