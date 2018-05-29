using App1.Models;
using App1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AgendamentoView : ContentPage
	{
        public AgendamentoViewModel ViewModel { get; set; }
        readonly Usuario usuario;

        public AgendamentoView (Veiculo veiculo, Usuario usuario)
		{
			InitializeComponent();
            this.ViewModel = new AgendamentoViewModel(veiculo, usuario);
            this.usuario = usuario;
            this.BindingContext = ViewModel;
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            AssinarMensagens();

        }

        private void AssinarMensagens()
        {
            MessagingCenter.Subscribe<Agendamento>(this, "Agendamento", async (msg) =>
            {

                var confirma = await DisplayAlert("Salvar Agendamento", "Você confirma o agendamento?", "Sim", "Não");

                if (confirma)
                {
                    this.ViewModel.SalvarAgendamento();
                }
            });

            MessagingCenter.Subscribe<Agendamento>(this, "SucessoAgendamento", (msg) =>
            {
                DisplayAlert("Agendamento", "Agendamento enviado com sucesso!", "OK");

                MessagingCenter.Send<Usuario>(this.usuario, "NovoAgendamento");

            });

            MessagingCenter.Subscribe<ArgumentException>(this, "ErroAgendamento", (msg) =>
            {
                DisplayAlert("Agendamento", "Falha ao enviar Agendamento. Tente novamente mais tarde.", "Fechar");
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            CancelarMensagens();
        }

        private void CancelarMensagens()
        {
            MessagingCenter.Unsubscribe<Agendamento>(this, "Agendamento");
            MessagingCenter.Unsubscribe<Agendamento>(this, "SucessoAgendamento");
            MessagingCenter.Unsubscribe<ArgumentException>(this, "ErroAgendamento");
        }
    }
}