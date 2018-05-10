namespace CaixaEletronico
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboConta = new System.Windows.Forms.ComboBox();
            this.textoTitular = new System.Windows.Forms.TextBox();
            this.textoSaldo = new System.Windows.Forms.TextBox();
            this.textoNumero = new System.Windows.Forms.TextBox();
            this.labelContas = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textoValor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btDeposito = new System.Windows.Forms.Button();
            this.btSaque = new System.Windows.Forms.Button();
            this.comboDestino = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btTransferencia = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboConta
            // 
            this.comboConta.FormattingEnabled = true;
            this.comboConta.Location = new System.Drawing.Point(117, 272);
            this.comboConta.Name = "comboConta";
            this.comboConta.Size = new System.Drawing.Size(159, 21);
            this.comboConta.TabIndex = 1;
            this.comboConta.SelectedIndexChanged += new System.EventHandler(this.comboConta_SelectedIndexChanged);
            // 
            // textoTitular
            // 
            this.textoTitular.Location = new System.Drawing.Point(117, 77);
            this.textoTitular.Name = "textoTitular";
            this.textoTitular.Size = new System.Drawing.Size(173, 20);
            this.textoTitular.TabIndex = 2;
            // 
            // textoSaldo
            // 
            this.textoSaldo.Location = new System.Drawing.Point(117, 129);
            this.textoSaldo.Name = "textoSaldo";
            this.textoSaldo.Size = new System.Drawing.Size(173, 20);
            this.textoSaldo.TabIndex = 3;
            // 
            // textoNumero
            // 
            this.textoNumero.Location = new System.Drawing.Point(117, 103);
            this.textoNumero.Name = "textoNumero";
            this.textoNumero.Size = new System.Drawing.Size(173, 20);
            this.textoNumero.TabIndex = 4;
            // 
            // labelContas
            // 
            this.labelContas.AutoSize = true;
            this.labelContas.Location = new System.Drawing.Point(60, 272);
            this.labelContas.Name = "labelContas";
            this.labelContas.Size = new System.Drawing.Size(40, 13);
            this.labelContas.TabIndex = 5;
            this.labelContas.Text = "Contas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Titular:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Saldo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Número:";
            // 
            // textoValor
            // 
            this.textoValor.Location = new System.Drawing.Point(117, 178);
            this.textoValor.Name = "textoValor";
            this.textoValor.Size = new System.Drawing.Size(173, 20);
            this.textoValor.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(64, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Valor:";
            // 
            // btDeposito
            // 
            this.btDeposito.Location = new System.Drawing.Point(117, 218);
            this.btDeposito.Name = "btDeposito";
            this.btDeposito.Size = new System.Drawing.Size(75, 23);
            this.btDeposito.TabIndex = 11;
            this.btDeposito.Text = "Depósito";
            this.btDeposito.UseVisualStyleBackColor = true;
            this.btDeposito.Click += new System.EventHandler(this.btDeposito_Click);
            // 
            // btSaque
            // 
            this.btSaque.Location = new System.Drawing.Point(210, 218);
            this.btSaque.Name = "btSaque";
            this.btSaque.Size = new System.Drawing.Size(75, 23);
            this.btSaque.TabIndex = 12;
            this.btSaque.Text = "Saque";
            this.btSaque.UseVisualStyleBackColor = true;
            this.btSaque.Click += new System.EventHandler(this.btSaque_Click);
            // 
            // comboDestino
            // 
            this.comboDestino.FormattingEnabled = true;
            this.comboDestino.Location = new System.Drawing.Point(117, 312);
            this.comboDestino.Name = "comboDestino";
            this.comboDestino.Size = new System.Drawing.Size(159, 21);
            this.comboDestino.TabIndex = 13;
            this.comboDestino.SelectedIndexChanged += new System.EventHandler(this.comboDestino_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(60, 315);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Destino";
            // 
            // btTransferencia
            // 
            this.btTransferencia.Enabled = false;
            this.btTransferencia.Location = new System.Drawing.Point(303, 312);
            this.btTransferencia.Name = "btTransferencia";
            this.btTransferencia.Size = new System.Drawing.Size(82, 23);
            this.btTransferencia.TabIndex = 15;
            this.btTransferencia.Text = "Transferência";
            this.btTransferencia.UseVisualStyleBackColor = true;
            this.btTransferencia.Click += new System.EventHandler(this.btTransferencia_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 345);
            this.Controls.Add(this.btTransferencia);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboDestino);
            this.Controls.Add(this.btSaque);
            this.Controls.Add(this.btDeposito);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textoValor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelContas);
            this.Controls.Add(this.textoNumero);
            this.Controls.Add(this.textoSaldo);
            this.Controls.Add(this.textoTitular);
            this.Controls.Add(this.comboConta);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboConta;
        private System.Windows.Forms.TextBox textoTitular;
        private System.Windows.Forms.TextBox textoSaldo;
        private System.Windows.Forms.TextBox textoNumero;
        private System.Windows.Forms.Label labelContas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textoValor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btDeposito;
        private System.Windows.Forms.Button btSaque;
        private System.Windows.Forms.ComboBox comboDestino;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btTransferencia;
    }
}

