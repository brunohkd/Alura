﻿using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Models
{
    public class Agendamento
    {
        public string Nome { get; set; }
        public string Fone { get; set; }
        public string Email { get; set; }
        public string Modelo { get; set; }
        public decimal Preco { get; set; }

        DateTime dataAgendamento = DateTime.Today;
        public DateTime DataAgendamento
        {
            get
            {
                return dataAgendamento;
            }
            set
            {
                dataAgendamento = value;
            }
        }

        TimeSpan horaAgendamento;
        public TimeSpan HoraAgendamento
        {
            get
            {
                return horaAgendamento;
            }
            set
            {
                horaAgendamento = value;
            }
        }

        public Agendamento(string nome, string fone, string email, string modelo, decimal preco)
        {
            this.Nome = nome;
            this.Fone = fone;
            this.Email = email;
            this.Modelo = modelo;
            this.Preco = preco;
        }

    }
}
