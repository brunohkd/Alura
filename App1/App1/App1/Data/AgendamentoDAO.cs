using App1.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Data
{
    class AgendamentoDAO
    {

        readonly SQLiteConnection conn;

        public AgendamentoDAO(SQLiteConnection conexao)
        {
            this.conn = conexao;
            this.conn.CreateTable<Agendamento>();
        }

        public void Salvar(Agendamento agendamento)
        {

        }

    }
}
