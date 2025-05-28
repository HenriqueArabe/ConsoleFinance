using System.Collections.Generic;
using System.Linq;
using ConsoleFinance.Models;

namespace ConsoleFinance.Services
{
    public class Banco
    {
        private readonly List<Conta> _contas = new();

        public void AdicionarConta(Conta conta)
        {
            _contas.Add(conta);
        }

        public IReadOnlyList<Conta> ListarContas()
        {
            return _contas.AsReadOnly();
        }

        public Conta? BuscarPorNumero(string numero)
        {
            return _contas.FirstOrDefault(c => c.Numero == numero);
        }
    }
}
