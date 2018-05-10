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
        Conta[] contas;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            contas = new Conta[2];
            contas[0] = new Conta();
            contas[0].numero = 1;
            contas[0].Cliente = new Cliente();
            contas[0].Cliente.nome = "Victor";

            contas[1] = new Conta();
            contas[1].numero = 2;
            contas[1].Cliente = new Cliente();
            contas[1].Cliente.nome = "Mario";

            foreach (Conta conta in contas) { 
                comboConta.Items.Add(conta.Cliente.nome);
                comboDestino.Items.Add(conta.Cliente.nome);
            }

        }

        private void comboConta_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboConta.SelectedIndex;
            Conta c = contas[index];

            textoTitular.Text = c.Cliente.nome;
            textoSaldo.Text = c.Saldo.ToString();
            textoNumero.Text = c.numero.ToString();
        }

        private void btDeposito_Click(object sender, EventArgs e)
        {
            if(textoValor.Text != null && textoValor.Text != "")
            {
                try
                {

                    double valor = Convert.ToDouble(textoValor.Text);

                    int index = comboConta.SelectedIndex;
                    Conta c = contas[index];

                    c.Deposita(valor);

                    MessageBox.Show("Valor Depositado com sucesso!");

                    textoSaldo.Text = c.Saldo.ToString();

                } catch (Exception ex)
                {
                    MessageBox.Show("O campo valor deve ser numérico.");
                }
            } else
            {
                MessageBox.Show("O campo Valor está vazio.");
            }
        }

        private void btSaque_Click(object sender, EventArgs e)
        {
            if (textoValor.Text != null && textoValor.Text != "")
            {
                try
                {

                    double valor = Convert.ToDouble(textoValor.Text);

                    int index = comboConta.SelectedIndex;
                    Conta c = contas[index];

                    bool v = c.Saca(valor);

                    if (v) { 
                        MessageBox.Show("Valor Sacado com sucesso!");
                        textoSaldo.Text = c.Saldo.ToString();
                    }
                    else
                        MessageBox.Show("Não foi possível efetuar o saque.");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("O campo valor deve ser numérico.");
                }
            }
            else
            {
                MessageBox.Show("O campo Valor está vazio.");
            }
        }

        private void comboDestino_SelectedIndexChanged(object sender, EventArgs e)
        {

            int index = comboDestino.SelectedIndex;
            Conta c = contas[index];

            if (c.Cliente.nome != null && c.Cliente.nome != "")
                btTransferencia.Enabled = true;
            else
                btTransferencia.Enabled = false;
        }

        private void btTransferencia_Click(object sender, EventArgs e)
        {
            if (textoValor.Text != null && textoValor.Text != "")
            {
                try
                {

                    double valor = Convert.ToDouble(textoValor.Text);

                    int index = comboDestino.SelectedIndex;
                    Conta c = contas[index];

                    bool v = c.Transfere(valor, c);

                    if (v)
                    {
                        MessageBox.Show("Valor Transferido com sucesso!");
                        textoSaldo.Text = c.Saldo.ToString();
                    }
                    else
                        MessageBox.Show("Não foi possível efetuar a transferência.");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("O campo valor deve ser numérico.");
                }
            }
            else
            {
                MessageBox.Show("O campo Valor está vazio.");
            }

            
        }
    }
}
