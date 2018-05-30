using App1.Data;
using App1.Models;
using App1.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace App1.ViewModels
{
    public class AgendamentoViewModel : BaseViewModel
    {
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
            AgendamentoService agendamentoService = new AgendamentoService();
            await agendamentoService.EnviarAgendamento(this.Agendamento);

        }

        
    }

}
