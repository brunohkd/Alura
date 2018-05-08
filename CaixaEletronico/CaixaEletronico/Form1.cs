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
    }
}
