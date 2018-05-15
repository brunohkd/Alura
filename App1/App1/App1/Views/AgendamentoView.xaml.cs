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

        public AgendamentoView (Veiculo veiculo)
		{
			InitializeComponent ();
            this.ViewModel = new AgendamentoViewModel(veiculo);
            this.BindingContext = ViewModel;
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Agendamento>(this, "Agendamento", (msg) =>
            {
                
                DisplayAlert("Agendamento", 
string.Format(@"Veiculo: {0}
Nome: {1}
Fone: {2}
Email: {3}
Data Agendamento: {4}
Hora Agendamento: {5}",
                    msg.Veiculo.Nome,
                    msg.Nome,
                    msg.Fone,
                    msg.Email,
                    msg.DataAgendamento.ToString("dd/MM/yyyy"),
                    msg.HoraAgendamento), "OK");
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Agendamento>(this, "Agendamento");
        }

    }
}