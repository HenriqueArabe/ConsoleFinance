using System;
using ConsoleFinance.Models;
using ConsoleFinance.Services;

namespace ConsoleFinance
{
    class Program
    {
        static void Main(string[] args)
        {
            var banco = new Banco();
            bool sair = false;

            while (!sair)
            {
                Console.Clear();
                Console.WriteLine("=== Console Finance ===");
                Console.WriteLine("1. Cadastrar conta");
                Console.WriteLine("2. Listar contas");
                Console.WriteLine("3. Depósito");
                Console.WriteLine("4. Saque");
                Console.WriteLine("5. Histórico");
                Console.WriteLine("0. Sair");
                Console.Write("Escolha uma opção: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        CadastrarConta(banco);
                        break;
                    case "2":
                        ListarContas(banco);
                        break;
                    case "3":
                        Operacao(banco, isDeposito: true);
                        break;
                    case "4":
                        Operacao(banco, isDeposito: false);
                        break;
                    case "5":
                        ExibirHistorico(banco);
                        break;
                    case "0":
                        sair = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tecle Enter para voltar.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        static void CadastrarConta(Banco banco)
        {
            Console.Clear();
            Console.Write("Número da conta: ");
            var numero = Console.ReadLine()!;
            Console.Write("Nome do titular: ");
            var nome = Console.ReadLine()!;
            Console.Write("CPF do titular: ");
            var cpf = Console.ReadLine()!;

            var conta = new Conta(numero, new Cliente(nome, cpf));
            banco.AdicionarConta(conta);

            Console.WriteLine("Conta cadastrada com sucesso! Tecle Enter.");
            Console.ReadLine();
        }

        static void ListarContas(Banco banco)
        {
            Console.Clear();
            Console.WriteLine("=== Contas Cadastradas ===");
            foreach (var c in banco.ListarContas())
                Console.WriteLine($"• {c.Numero} — {c.Titular.Nome} — Saldo: {c.Saldo:C}");
            Console.WriteLine("\nTecle Enter para voltar.");
            Console.ReadLine();
        }

        static void Operacao(Banco banco, bool isDeposito)
        {
            Console.Clear();
            Console.Write("Número da conta: ");
            var numero = Console.ReadLine()!;
            var conta = banco.BuscarPorNumero(numero);
            if (conta == null)
            {
                Console.WriteLine("Conta não encontrada. Tecle Enter.");
                Console.ReadLine();
                return;
            }

            Console.Write(isDeposito ? "Valor do depósito: " : "Valor do saque: ");
            if (!decimal.TryParse(Console.ReadLine(), out var valor))
            {
                Console.WriteLine("Valor inválido. Tecle Enter.");
                Console.ReadLine();
                return;
            }

            bool ok;
            if (isDeposito)
            {
                conta.Depositar(valor);
                ok = true;
            }
            else
            {
                ok = conta.Sacar(valor);
            }

            Console.WriteLine(ok
                ? "Operação realizada com sucesso!"
                : "Saldo insuficiente.");
            Console.WriteLine("Tecle Enter para voltar.");
            Console.ReadLine();
        }

        static void ExibirHistorico(Banco banco)
        {
            Console.Clear();
            Console.Write("Número da conta: ");
            var numero = Console.ReadLine()!;
            var conta = banco.BuscarPorNumero(numero);
            if (conta == null)
            {
                Console.WriteLine("Conta não encontrada.");
            }
            else
            {
                Console.WriteLine($"Histórico da conta {conta.Numero}:");
                foreach (var entry in conta.Historico)
                    Console.WriteLine($"- {entry}");
            }
            Console.WriteLine("\nTecle Enter para voltar.");
            Console.ReadLine();
        }
    }
}
