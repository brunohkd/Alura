using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaixaEletronico
{
    class Cliente
    {
        public string nome;
        public string rg;
        public string endereco;
        public int idade;
        public string cpf;
    }

    public bool PodeAbrirContaSozinho
    {
        get
        {
            bool maiorDeIdade = this.idade >= 18;
            bool emancipado = this.documento.contains("emancipacao");
            bool possuiCpf = !string.IsNullOrEmpty(this.cpf);
            
            return (maiorDeIdade || emancipado) && possuiCpf;
        };
    }
}
