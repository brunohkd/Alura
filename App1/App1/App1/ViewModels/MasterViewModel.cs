using App1.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App1.ViewModels
{

    public class MasterViewModel
    {
        private Usuario usuario;

        public Usuario Usuario
        {
            get { return this.Usuario; }
            set { this.Usuario = value; }
        }

        public MasterViewModel(Usuario usuario)
        {
            this.usuario = usuario;
            EditarPerfilCommand = new Command(() =>
            {
                MessagingCenter.Send<Usuario>(usuario, "EditarPerfil");
            });
;        }

        private string nome = "Meu nome";

        public string Nome
        {
            get { return this.usuario.nome; }
            set { this.usuario.nome = value; }
        }

        private string email = "meuemail@gmail.com";

        public string Email
        {
            get { return this.usuario.email; }
            set { this.usuario.email = value; }
        }

        public ICommand EditarPerfilCommand { get; private set; }

    }
}
