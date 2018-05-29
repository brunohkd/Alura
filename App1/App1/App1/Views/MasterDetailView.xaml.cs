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
    public partial class MasterDetailView : MasterDetailPage
    {

        public Usuario usuario;

        public MasterDetailView(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.Master = new MasterView(usuario);
            this.Detail = new NavigationPage(new ListagemView(usuario));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            AssinarMensagens();
        }

        private void AssinarMensagens()
        {
            MessagingCenter.Subscribe<Usuario>(this, "MeusAgendamentos", (usuario) =>
            {
                this.Detail = new NavigationPage(new AgendamentosUsuarioView());
                this.IsPresented = false;
            });
            MessagingCenter.Subscribe<Usuario>(this, "NovoAgendamento", (usuario) =>
            {
                this.Detail = new NavigationPage(new ListagemView(usuario));
                this.IsPresented = false;
            });
        }
    }
}