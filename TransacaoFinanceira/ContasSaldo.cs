using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransacaoFinanceira
{
    public class ContasSaldo
    {
        private uint _conta;
        private decimal _saldo;

        public ContasSaldo(uint conta, decimal saldoInicial)
        {
            this._conta = conta;
            this._saldo = saldoInicial;
        }

        public decimal GetConta()
        {
            return _conta;
        }

        public decimal GetSaldo()
        {
            return _saldo;
        }

        public void Creditar(decimal valor)
        {
            _saldo += valor;
        }

        public void Debitar(decimal valor)
        {
            if (_saldo >= valor)
            {
                _saldo -= valor;
            }
            else
            {
                throw new InvalidOperationException("Saldo insuficiente.");
            }
        }
    }
}
