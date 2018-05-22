using App1.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App1.ViewModels
{

    public class MasterViewModel : BaseViewModel
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
            DefinirComandos(usuario);
        }

        private void DefinirComandos(Usuario usuario)
        {
            EditarPerfilCommand = new Command(() =>
            {
                MessagingCenter.Send<Usuario>(usuario, "EditarPerfil");
            });
            SalvarDadosCommand = new Command(() =>
            {
                MessagingCenter.Send<Usuario>(usuario, "SucessoSalvarUsuario");
                Editando = false;
                OnPropertyChanged();
            });
            EditarDadosCommand = new Command(() =>
            {
                this.Editando = true;
            });
        }

        //private string nome = "Meu nome";

        public string Nome
        {
            get { return this.usuario.nome; }
            set { this.usuario.nome = value; }
        }

        //private string email = "meuemail@gmail.com";

        public string Email
        {
            get { return this.usuario.email; }
            set { this.usuario.email = value; }
        }

        //private string dataNascimento;

        public string DataNascimento
        {
            get { return this.usuario.dataNascimento; }
            set { this.usuario.dataNascimento = value; }
        }

        //private string telefone;

        public string Telefone
        {
            get { return this.usuario.telefone; }
            set { this.usuario.telefone = value; }
        }

        private bool editando = false;
        public bool Editando
        {
            get { return editando; }
            private set {
                editando = value;
                OnPropertyChanged();
            }
        }

        private ImageSource fotoPerfil = "profile.png";
        public ImageSource FotoPerfil
        {
            get { return fotoPerfil; }
            set { fotoPerfil = value; }
        }

        public ICommand EditarPerfilCommand { get; private set; }

        public ICommand SalvarDadosCommand { get; private set; }

        public ICommand EditarDadosCommand { get; private set; }

    }
}
