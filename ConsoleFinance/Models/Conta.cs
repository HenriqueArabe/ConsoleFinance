using System;
using System.Collections.Generic;

namespace ConsoleFinance.Models
{
    public class Conta
    {
        public string Numero { get; }
        public Cliente Titular { get; }
        public decimal Saldo { get; private set; }

        private List<string> _historico = new List<string>();
        public IReadOnlyList<string> Historico => _historico.AsReadOnly();

        public Conta(string numero, Cliente titular)
        {
            Numero = numero;
            Titular = titular;
            Saldo = 0m;
        }

        public void Depositar(decimal valor)
        {
            Saldo += valor;
            _historico.Add($"Depósito: +{valor:C} em {DateTime.Now}");
        }

        public bool Sacar(decimal valor)
        {
            if (valor > Saldo) return false;
            Saldo -= valor;
            _historico.Add($"Saque: -{valor:C} em {DateTime.Now}");
            return true;
        }
    }
}
