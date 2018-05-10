using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaixaEletronico
{
    class Conta
    {
        public double Saldo { get; set; }
        public int numero;
        public int agencia;

        public Cliente Cliente { get; set; }
        
        

        public bool Saca(double valor)
        {
            if(this.Saldo >= valor && valor >= 0 && valor < 200) { 
                this.Saldo -= valor;
                return true;
            } else
            {
                return false;
            }
        }

        public void Deposita(double valor)
        {
            this.Saldo += valor;
        }

        public bool Transfere(double valor, Conta destino)
        {
            bool v = this.Saca(valor);
            if (v)
            {
                destino.Deposita(valor);
                return true;
            }
            else
                return false;
        }

        public double CalculaRendimentoAnual()
        {
            double saldoNaqueleMes = this.Saldo;

            for (int i = 0; i < 12; i++)
            {
                saldoNaqueleMes = saldoNaqueleMes * 1.007;
            }

            double rendimento = saldoNaqueleMes - this.Saldo;

            return rendimento;
        }

        public virtual void Atualiza(double taxa)
        {
            this.Saldo += this.Saldo * taxa;
        }

    }
}
