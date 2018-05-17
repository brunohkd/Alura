using App1.Models;
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
    public class LoginViewModel : BaseViewModel
    {

        public LoginViewModel()
        {
            EntrarCommand = new Command( async () =>
            {
                var loginService = new LoginService();
                await loginService.FazerLogin(new Login(usuario, senha));

            }, () =>
            {
                return !string.IsNullOrEmpty(usuario) && !string.IsNullOrEmpty(senha);
            });
        }

        private string usuario;
        public string Usuario
        {
            get { return usuario; }
            set
            {
                usuario = value;
                ((Command)EntrarCommand).ChangeCanExecute();
            }
        }

        private string senha;
        public string Senha
        {
            get { return senha; }
            set
            {
                senha = value;
                ((Command)EntrarCommand).ChangeCanExecute();
            }
        }

        public ICommand EntrarCommand { get; private set; }

    }


    class UsuarioJson
    {
        public long id { get; set; }
        public string nome { get; set; }
        public DateTime dataNascimento { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
    }

}
