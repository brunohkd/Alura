using App1.Models;
using App1.Services;
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
	public partial class AgendamentosUsuarioView : ContentPage
	{

        readonly AgendamentosUsuarioViewModel _viewModel;

		public AgendamentosUsuarioView ()
		{
			InitializeComponent ();
            this._viewModel = new AgendamentosUsuarioViewModel();
            this.BindingContext = this._viewModel;
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<Agendamento>(this, "AgendamentoSelecionado", async (agendadmento) =>
            {
                if (!agendadmento.Confirmado) { 
                    var reenviar = await DisplayAlert("Reenviar", "Deseja reenviar o agendamento?", "Sim", "Não");
                    if(reenviar)
                    {
                        AgendamentoService agendamentoService = new AgendamentoService();
                        await agendamentoService.EnviarAgendamento(agendadmento);
                        this._viewModel.AtualizarLista();
                    }
                }
            });

            MessagingCenter.Subscribe<Agendamento>(this, "SucessoAgendamento", async (agendamento) =>
            {
                await DisplayAlert("Reenviar", "Reenvio com sucesso!", "OK");

            });

            MessagingCenter.Subscribe<Agendamento>(this, "FalhaAgendamento", async (agendamento) =>
            {
                await DisplayAlert("Reenviar", "Falha ao reenviar!", "OK");
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Agendamento>(this, "AgendamentoSelecionado");
            MessagingCenter.Unsubscribe<Agendamento>(this, "SucessAgendamento");
            MessagingCenter.Unsubscribe<Agendamento>(this, "FalhaAgendamento");
        }
    }
}