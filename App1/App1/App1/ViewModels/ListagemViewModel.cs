using App1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1.ViewModels
{
    public class ListagemViewModel : BaseViewModel
    {
        const string URL_GET_VEICULOS = "http://aluracar.herokuapp.com/";

        public ObservableCollection<Veiculo> Veiculos { get; set; }

        Veiculo veiculoSelecionado = new Veiculo();

        public Veiculo VeiculoSelecionado
        {
            get
            {
                return veiculoSelecionado;
            }
            set
            {
                veiculoSelecionado = value;
                MessagingCenter.Send<Veiculo>(veiculoSelecionado, "VeiculoSelecionado");
                OnPropertyChanged("VeiculoSelecionado");
            }
        }

        readonly Usuario usuario;

        public ListagemViewModel(Usuario usuario)
        {
            this.Veiculos = new ObservableCollection<Veiculo>();
            this.usuario = usuario;
        }

        public async Task GetVeiculos()
        {
            Aguarde = true;

            HttpClient cliente = new HttpClient();
            cliente.Timeout = new TimeSpan(0, 0, 5);

            var resultado = await cliente.GetStringAsync(URL_GET_VEICULOS);

            var veiculosJson = JsonConvert.DeserializeObject<VeiculoJson[]>(resultado);

            foreach (var veiculoJson in veiculosJson)
            {
                this.Veiculos.Add(new Veiculo()
                {
                    Nome = veiculoJson.nome,
                    Preco = veiculoJson.preco
                });
            }

            Aguarde = false;
        }

        private bool aguarde;

        public bool Aguarde
        {
            get { return aguarde; }
            set
            {
                aguarde = value;
                OnPropertyChanged("Aguarde");
            }
        }

    }
}

class VeiculoJson
{
    public string nome { get; set; }
    public decimal preco { get; set; }
}