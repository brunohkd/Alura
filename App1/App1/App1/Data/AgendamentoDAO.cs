using App1.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App1.Data
{
    class AgendamentoDAO
    {

        readonly SQLiteConnection conn;

        private List<Agendamento> lista;
        public List<Agendamento> Lista
        {
            get
            {
                return conn.Table<Agendamento>().ToList();
            }
            private set { lista = value; }
        }

        public AgendamentoDAO(SQLiteConnection conexao)
        {
            this.conn = conexao;
            this.conn.CreateTable<Agendamento>();
        }

        public void Salvar(Agendamento agendamento)
        {
            try {

               if(conn.Find<Agendamento>(agendamento.ID) == null)
                {
                    conn.Insert(agendamento);
                }
                else
                {
                    conn.Update(agendamento);
                }
            } catch (Exception)
            {
                conn.Rollback();
            }
        }


    }
}
