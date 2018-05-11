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
	public partial class DetalheView : ContentPage
	{

        public const int FREIO_ABS = 800;
        public const int AR_CONDICIONADO = 1000;
        public const int MP3_PLAYER = 500;

        public Veiculo Veiculo { get; set; }

        public string TextoFreioABS { get { return string.Format("Freio ABS - R$ {0}", FREIO_ABS); } }
        public string TextoArCondicionado { get { return string.Format("Ar Condicionado - R$ {0}", AR_CONDICIONADO); } }
        public string TextoMP3Player { get { return string.Format("MP3 Player - R$ {0}", MP3_PLAYER); } }

        public string ValorTotal
        {
            get
            {
                decimal valor = Veiculo.Preco;
                if (TemFreioABS)
                    valor += FREIO_ABS;
                if (TemArCondicionado)
                    valor += AR_CONDICIONADO;
                if (TemMP3Player)
                    valor += MP3_PLAYER;

                return string.Format("Total: R$ {0}", valor);
            }
        }

        private bool temFreioABS;
        public bool TemFreioABS {
            get
            {
                return temFreioABS;
            }
            set
            {
                temFreioABS = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            }
        }

        private bool temArCondicionado;
        public bool TemArCondicionado {
            get
            {
                return temArCondicionado;
            }
            set
            {
                temArCondicionado = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            }
        }

        private bool temMP3Player;
        public bool TemMP3Player {
            get
            {
                return temMP3Player;
            }
            set
            {
                temMP3Player = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            }
        }

		public DetalheView (Veiculo veiculo)
		{
			InitializeComponent ();
            this.Veiculo = veiculo;

            this.BindingContext = this;
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Views.AgendamentoView(this.Veiculo));
        }
    }
}