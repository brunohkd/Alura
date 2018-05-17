﻿using App1.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    public class LoginService
    {
        const string URL_POST_LOGIN = "https://aluracar.herokuapp.com/login";

        public async Task FazerLogin(Login login)
        {
            try
            {
                using (var cliente = new HttpClient())
                {
                    var camposFormulario = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("email", login.email), //joao@alura.com
                        new KeyValuePair<string, string>("senha", login.senha) //alura123
                    });

                    //cliente.BaseAddress = new Uri(URL_POST_LOGIN);
                    var resposta = await cliente.PostAsync(URL_POST_LOGIN, camposFormulario);

                    if (resposta.IsSuccessStatusCode)
                    {
                        MessagingCenter.Send<Usuario>(new Usuario(), "SucessoLogin");
                    }
                    else
                    {
                        MessagingCenter.Send<LoginException>(new LoginException("Usuário ou Senha incorretos."), "FalhaLogin");
                    }
                }
            }
            catch 
            {
                MessagingCenter.Send<LoginException>(new LoginException(@"Ocorreu um erro inesperado.
Por favor, verifique sua conexão e tente novamente mais tarde."), "FalhaLogin");
            }
        }
    }

    public class LoginException : Exception
    {
        public LoginException(string message) : base(message)
        {

        }
    }

}
