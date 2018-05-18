using App1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace App1.ViewModels
{

    public class MasterViewModel
    {
        private readonly Usuario usuario;

        public MasterViewModel(Usuario usuario)
        {
            this.usuario = usuario;                                                                                  
        }

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


    }
}
