using ConsoleFinance.Models;
using ConsoleFinance.Services;

class Program
{
    static void Main(string[] args)
    {
        var banco = new Banco();

        // Cria dois clientes e contas
        var cliente1 = new Cliente("Alice", "111.222.333-44");
        var conta1 = new Conta("0001", cliente1);
        banco.AdicionarConta(conta1);

        var cliente2 = new Cliente("Bob", "555.666.777-88");
        var conta2 = new Conta("0002", cliente2);
        banco.AdicionarConta(conta2);

        // Opera sobre conta 0001
        conta1.Depositar(500m);
        conta1.Sacar(150m);

        // Lista todas as contas e seus saldos
        foreach (var conta in banco.ListarContas())
        {
            Console.WriteLine($"Conta {conta.Numero} — Titular: {conta.Titular.Nome} — Saldo: {conta.Saldo:C}");
        }

        // Exibe histórico da conta1
        Console.WriteLine("\nHistórico da conta 0001:");
        foreach (var entry in conta1.Historico)
            Console.WriteLine($"  {entry}");
    }
}
