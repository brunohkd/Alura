using App1.Media;
using App1.Models;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App1.ViewModels
{

    public class MasterViewModel : BaseViewModel
    {
        private readonly Usuario usuario;

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
            TirarFotoCommand = new Command(() =>
            {
                DependencyService.Get<ICamera>().TirarFoto();
            });
        }

        public string Nome
        {
            get { return this.usuario.nome; }
            set { this.usuario.nome = value; }
        }

        public string Email
        {
            get { return this.usuario.email; }
            set { this.usuario.email = value; }
        }

        public string DataNascimento
        {
            get { return this.usuario.dataNascimento; }
            set { this.usuario.dataNascimento = value; }
        }

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

        public ICommand TirarFotoCommand { get; private set; }

    }
}
