using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaixaEletronico
{
    class ContaCorrente : Conta
    {
        public override void Atualiza(double taxa)
        {
            this.Saldo += this.Saldo * 2 * taxa;
        }
    }

    class TotalizadorDeContas
    {
        public double SaldoTotal { get; set; }

        public void Adiciona(ContaCorrente c)
        {
            this.SaldoTotal += + c.Saldo;
        }
    }
}
