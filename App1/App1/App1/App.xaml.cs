using App1.Models;
using App1.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace App1
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            MainPage = new LoginView();
			//MainPage = new NavigationPage(new ListagemView());
		}

		protected override void OnStart ()
		{
            // Handle when your app starts

            MessagingCenter.Subscribe<Usuario>(this, "SucessoLogin", (usuario) =>
            {
                MainPage = new MasterDetailView(usuario);

                //MessagingCenter.Send<Usuario>(usuario, "MasterUsuario");

            });

		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
