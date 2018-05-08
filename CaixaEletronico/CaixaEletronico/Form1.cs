using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaixaEletronico
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int numeroDaConta;
            numeroDaConta = 1;

            double saldo = 100.0;
            double valor = 10.0;
            double saldoAposSaque = 100.0 - valor;


            MessageBox.Show("O saldo atual é: " + saldoAposSaque);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int idadeBianca = 23;
            int idadeJoao = 26;
            int idadeBruno = 27;

            MessageBox.Show("A média de idade é: " + (idadeBianca+idadeJoao+idadeBruno)/3);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show("Valor: " + (10*(1+2)));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string ola = "Hello ";
            string mundo = "World ";
            string daCaelum = "da Caelum";
            string texto = ola + mundo + daCaelum;

            MessageBox.Show(texto);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            double pi = 3.14;
            int piQuebrado = (int)pi;

            MessageBox.Show("Valor " + piQuebrado);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //báscara

            int a = 12;
            int b = -3;
            int c = 5;
            double delta;
            double a1;
            double a2;

            delta = b * b - 4 * a * c;
            a1 = (-b + Math.Sqrt(delta)) / (2 * a);
            a2 = (-b - Math.Sqrt(delta)) / (2 * a);

            MessageBox.Show("Valor 1 = " + a1 + ", Valor 2 = " + a2);

        }

        private void button7_Click(object sender, EventArgs e)
        {
            double saldo = 100.0;
            double valor = 10.0;

            bool podeSacar = (valor <= saldo) && (valor >= 0);

            if(podeSacar) {
                saldo = saldo - valor;
                MessageBox.Show("Saque Realizado com sucesso. Seu saldo é de: " + saldo);
            } else {
                MessageBox.Show("Saldo Insuficiente.");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            double valorDaNotaFiscal = 5000.0;

            if (valorDaNotaFiscal < 1000)
            {
                MessageBox.Show("Imposto 2%: " + (valorDaNotaFiscal * 2) / 100);
            }
            else if (valorDaNotaFiscal >= 1000 && valorDaNotaFiscal < 3000)
            {
                MessageBox.Show("Imposto 2,5%: " + (valorDaNotaFiscal * 2.5) / 100);
            }
            else if (valorDaNotaFiscal >= 3000 && valorDaNotaFiscal < 7000)
            {
                MessageBox.Show("Imposto 2,8%: " + (valorDaNotaFiscal * 2.8) / 100);
            }
            else if (valorDaNotaFiscal >= 7000)
            {
                MessageBox.Show("Imposto 3%: " + (valorDaNotaFiscal * 3) / 100);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int total = 0;
            for (int i = 0; i < 10; i++)
            {
                total += 1;
            }
            MessageBox.Show("Resultado: " + total);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int i = 10;
            while (i < 5)
            {
                MessageBox.Show("Entrei no while");
            }

            do
            {
                MessageBox.Show("Entrei no do..while");
            } while (i < 5);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            for(int i = 1; i<= 100; i++)
            {
                if (i % 3 == 0)
                {
                    MessageBox.Show(i + " é múltiplo de 3.");
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            int fatorial = 1;
            for (int n = 1; n <= 10; n++)
            {
                fatorial = fatorial * n;
                MessageBox.Show("Fatorial(" + n + ") = " + fatorial);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            string serieFibonacci = "";
            int anterior = 0;
            int atual = 1;
            while (atual <= 100)
            {
                serieFibonacci += atual + " ";
                int proximo = anterior + atual;
                anterior = atual;
                atual = proximo;
            }
            MessageBox.Show("A série de Fibonacci até 100: " + serieFibonacci);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            int qtdLinhas = 5;
            string triangulo = "";
            for (int linha = 1; linha <= qtdLinhas; linha++)
            {
                for (int coluna = 1; coluna <= linha; coluna++)
                {
                    triangulo += (linha * coluna) + " ";
                }
                triangulo += "\n";
            }
            MessageBox.Show(triangulo);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            int divisivel1 = 15 % 3;
            int divisivel2 = 15 % 4;

            string msg = "";

            if(divisivel1 == 0)
            {
                msg = "15 é divisível por 3 e ";
            } else
            {
                msg = "15 não é divisível por 3 e ";
            }

            if(divisivel2 == 0)
            {
                msg += "é divisível por 4.";
            } else
            {
                msg += "não é divisível por 4.";
            }

            MessageBox.Show(msg);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            string div3 = "De 0 a 30 divisíveis por 3: ";
            string div4 = "De 0 a 30 divisíveis por 4: ";

            int count3 = 0;
            int count4 = 0;

            for (int i = 0; i <= 30; i++)
            {
                if(i % 3 == 0)
                {
                    if (count3 == 0)
                    {
                        count3 += 1;
                        div3 += i;
                    }
                    else { 
                        div3 += ", " + i;
                    }
                }
                if (i % 4 == 0)
                {
                    if (count4 == 0) { 
                        count4 += 1;
                        div4 += i;
                    }
                    else { 
                        div4 += ", " + i;
                    }
                }
            }

            MessageBox.Show(div3 + ".\n" + div4 + ".");
        }

        private void button17_Click(object sender, EventArgs e)
        {

            int result = 0;

            for(int i = 1; i <=100; i++)
            {
                if(i % 3 != 0)
                {
                    result += i;
                }

            }

            MessageBox.Show(result.ToString());
        }
    }
}
