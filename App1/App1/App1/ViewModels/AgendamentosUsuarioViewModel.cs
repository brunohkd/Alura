using App1.Data;
using App1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public AgendamentosUsuarioViewModel()
        {
            using (var conn = DependencyService.Get<ISQLite>().PegarConexao())
            {
                AgendamentoDAO dao = new AgendamentoDAO(conn);
                var listaDB = dao.Lista;
                this.Lista.Clear();
                foreach (var itemDB in listaDB)
                {
                    this.lista.Add(itemDB);
                }
            }

        }
    }
}
