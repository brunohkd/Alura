using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Models
{
    public class ListagemVeiculos
    {

        public List<Veiculo> Veiculos { get; set; }

        public ListagemVeiculos()
        {
             this.Veiculos = new List<Veiculo>
            {
                new Veiculo { Nome = "Azera V6", Preco = 60000 },
                new Veiculo { Nome = "Fiesta 2.0", Preco = 500000 },
                new Veiculo { Nome = "HB20 S", Preco = 40000 },
                new Veiculo { Nome = "Hilux 4x4", Preco = 90000 }
            };
        }
    }
}
