using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace AgendaContato.Models
{
    [Table("tb_contato")]
    public class ContatoModel
    {
        [PrimaryKey, Column("id")]
        public string Id { get; set; }

        [Column("nome"), Indexed]
        public string Nome { get; set; }

        [Column("profissao")]
        public string Profissao { get; set; }

        [Column("cidade")]
        public string Cidade { get; set; }
    }
}
