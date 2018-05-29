using App1.Data;
using App1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App1.ViewModels
{
    public class AgendamentoViewModel : BaseViewModel
    {
        const string URL_POST_SALVAR_AGENDAMENTO = "http://aluracar.herokuapp.com/salvaragendamento";

        public Agendamento Agendamento { get; set; }
        
        public string Nome
        {
            get
            {
                return this.Agendamento.Nome;
            }
            set
            {
                this.Agendamento.Nome = value;
                OnPropertyChanged();
                ((Command)AgendarCommand).ChangeCanExecute();
            }
        }
        public string Fone
        {
            get
            {
                return this.Agendamento.Fone;
            }
            set
            {
                this.Agendamento.Fone = value;
                OnPropertyChanged();
                ((Command)AgendarCommand).ChangeCanExecute();
            }
        }
        public string Email
        {
            get
            {
                return this.Agendamento.Email;
            }
            set
            {
                this.Agendamento.Email = value;
                OnPropertyChanged();
                ((Command)AgendarCommand).ChangeCanExecute();
            }
        }

        public DateTime DataAgendamento
        {
            get
            {
                return this.Agendamento.DataAgendamento;
            }
            set
            {
                this.Agendamento.DataAgendamento = value;
            }
        }

        public TimeSpan HoraAgendamento
        {
            get
            {
                return this.Agendamento.HoraAgendamento;
            }
            set
            {
                this.Agendamento.HoraAgendamento = value;
            }
        }

        public string Modelo
        {
            get { return this.Agendamento.Modelo; }
            set { this.Agendamento.Modelo = value; }
        }

        public decimal Preco
        {
            get { return this.Agendamento.Preco; }
            set { this.Agendamento.Preco = value; }
        }


        public AgendamentoViewModel(Veiculo veiculo, Usuario usuario)
        {
            this.Agendamento = new Agendamento(usuario.nome, usuario.telefone, usuario.email, veiculo.Nome, veiculo.Preco);

            AgendarCommand = new Command(() => {
                MessagingCenter.Send<Agendamento>(this.Agendamento, "Agendamento");
            }, () =>
            {
                return !string.IsNullOrEmpty(Nome) && !string.IsNullOrEmpty(Fone) && !string.IsNullOrEmpty(Email);
            });
        }

        public ICommand AgendarCommand { get; set; }


        public async void SalvarAgendamento()
        {
            HttpClient cliente = new HttpClient();

            var dataHoraAgendamento = new DateTime(DataAgendamento.Year, DataAgendamento.Month, DataAgendamento.Day,
                HoraAgendamento.Hours, HoraAgendamento.Minutes, HoraAgendamento.Seconds);

            var json = JsonConvert.SerializeObject(new
            {
                nome = Nome,
                fone = Fone,
                email = Email,
                carro = Modelo,
                preco = Preco,
                dataAgendamento = dataHoraAgendamento
            });

            var conteudo = new StringContent(json, Encoding.UTF8, "application/json");

            var resposta = await cliente.PostAsync(URL_POST_SALVAR_AGENDAMENTO, conteudo);
            SalvarAgendamentoDB();

            if (resposta.IsSuccessStatusCode)
            {

                MessagingCenter.Send<Agendamento>(this.Agendamento, "SucessoAgendamento");

            }
            else
            {
                MessagingCenter.Send<ArgumentException>(new ArgumentException(), "ErroAgendamento");
            }

        }

        private void SalvarAgendamentoDB()
        {
            using (var conexao = DependencyService.Get<ISQLite>().PegarConexao())
            {

                AgendamentoDAO dao = new AgendamentoDAO(conexao);

                dao.Salvar(new Agendamento(Nome, Fone, Email, Modelo, Preco));
            }
        }
    }
}
