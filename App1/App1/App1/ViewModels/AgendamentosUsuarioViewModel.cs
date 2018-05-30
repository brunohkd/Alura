using App1.Data;
using App1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace App1.ViewModels
{
    class AgendamentosUsuarioViewModel : BaseViewModel
    {
        ObservableCollection<Agendamento> lista = new ObservableCollection<Agendamento>();
        public ObservableCollection<Agendamento> Lista {
            get
            {
                return lista;
            }
            private set
            {
                lista = value;
                OnPropertyChanged();
            }
        }

        private Agendamento agendamentoSelecionado;

        public Agendamento AgendamentoSelecionado
        {
            get { return agendamentoSelecionado; }
            set
            {
                if(value != null) { 
                    agendamentoSelecionado = value;
                    MessagingCenter.Send<Agendamento>(agendamentoSelecionado, "AgendamentoSelecionado");
                }
            }
        }


        public AgendamentosUsuarioViewModel()
        {
            AtualizarLista();

        }

        public void AtualizarLista()
        {
            using (var conn = DependencyService.Get<ISQLite>().PegarConexao())
            {
                AgendamentoDAO dao = new AgendamentoDAO(conn);
                var listaDB = dao.Lista;

                var query = listaDB.OrderBy(l => l.DataAgendamento)
                    .ThenBy(l => l.HoraAgendamento);

                this.Lista.Clear();
                foreach (var itemDB in query)
                {
                    this.lista.Add(itemDB);
                }
            }
        }
    }
}
