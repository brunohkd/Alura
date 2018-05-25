using App1.Models;
using App1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1.Views
{

	public partial class ListagemView : ContentPage
	{
        public ListagemViewModel ViewModel { get; set; }
        readonly Usuario usuario;

		public ListagemView(Usuario usuario)
		{
		    InitializeComponent();
            this.ViewModel = new ListagemViewModel();
            this.usuario = usuario;
            this.BindingContext = this.ViewModel;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            AssinarMensagens();

            await this.ViewModel.GetVeiculos();

        }

        private void AssinarMensagens()
        {
            MessagingCenter.Subscribe<Veiculo>(this, "VeiculoSelecionado",
                           (veiculo) =>
                           {
                               Navigation.PushAsync(new DetalheView(veiculo, this.usuario));
                           });
            MessagingCenter.Subscribe<Exception>(this, "FalhaListagem", (msg) =>
            {
                DisplayAlert("Erro", "Ocorreu um erro ao obter a listagem de veículos.", "OK");
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Veiculo>(this, "VeiculoSelecionado");
            MessagingCenter.Unsubscribe<Exception>(this, "FalhaListagem");
        }

    }
}
