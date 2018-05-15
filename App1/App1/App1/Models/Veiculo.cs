using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Models
{
    public class Veiculo
    {
        public const int FREIO_ABS = 800;
        public const int AR_CONDICIONADO = 1000;
        public const int MP3_PLAYER = 500;

        public string Nome { get; set; }
        public decimal Preco { get; set; }

        public string PrecoFormatado
        {
            get { return string.Format("R$ {0}", Preco); }
        }

        public bool TemFreioABS { get; set; }
        public bool TemArCondicionado { get; set; }
        public bool TemMP3Player { get; set; }

        public string PrecoTotalFormatado(decimal Preco)
        {
            decimal valor = Preco;
            if (TemFreioABS)
                valor += Veiculo.FREIO_ABS;
            if (TemArCondicionado)
                valor += Veiculo.AR_CONDICIONADO;
            if (TemMP3Player)
                valor += Veiculo.MP3_PLAYER;

            return string.Format("Total: R$ {0}", valor);
        }
    }
}
