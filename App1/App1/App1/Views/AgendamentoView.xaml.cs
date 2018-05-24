﻿using App1.Models;
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

        public AgendamentoView (Veiculo veiculo)
		{
			InitializeComponent();
            this.ViewModel = new AgendamentoViewModel(veiculo);
            this.BindingContext = ViewModel;
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Agendamento>(this, "Agendamento", async (msg) =>
            {

                var confirma = await DisplayAlert("Salvar Agendamento", "Você confirma o agendamento?", "Sim", "Não");

                if(confirma)
                {
                    this.ViewModel.SalvarAgendamento();
                }
            });

            MessagingCenter.Subscribe<Agendamento>(this, "SucessoAgendamento", (msg) =>
            {
                DisplayAlert("Agendamento", "Agendamento enviado com sucesso!", "OK");
            });

            MessagingCenter.Subscribe<ArgumentException>(this, "ErroAgendamento", (msg) =>
            {
                DisplayAlert("Agendamento", "Falha ao enviar Agendamento. Tente novamente mais tarde.", "Fechar");
            });

        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Agendamento>(this, "Agendamento");
            MessagingCenter.Unsubscribe<Agendamento>(this, "SucessoAgendamento");
            MessagingCenter.Unsubscribe<ArgumentException>(this, "ErroAgendamento");
        }

    }
}