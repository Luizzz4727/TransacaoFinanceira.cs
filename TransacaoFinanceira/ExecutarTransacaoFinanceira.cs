using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransacaoFinanceira
{
    public class ExecutarTransacaoFinanceira : IServicoTransacao
    {
        private readonly IRepositorioContas _repository;

        public ExecutarTransacaoFinanceira(IRepositorioContas repository)
        {
            _repository = repository;
        }

        public void Transferir(int correlationId, uint contaOrigem, uint contaDestino, decimal valor)
        {
            var contaSaldoOrigem = _repository.GetRegistroConta(contaOrigem);
            var contaSaldoDestino = _repository.GetRegistroConta(contaDestino);

            if (contaSaldoOrigem == null)
            {
                Console.WriteLine("Transacao numero {0} foi cancelada: Conta de origem não existe", correlationId);
                return;
            }

            if (contaSaldoDestino == null)
            {
                Console.WriteLine("Transacao numero {0} foi cancelada: Conta de destino não existe", correlationId);
                return;
            }

            if (contaSaldoOrigem.GetSaldo() < valor)
            {
                Console.WriteLine("Transacao numero {0} foi cancelada por falta de saldo", correlationId);
                return;
            }

            // Realiza a transferência
            contaSaldoOrigem.Debitar(valor);
            contaSaldoDestino.Creditar(valor);

            Console.WriteLine("Transacao numero {0} foi efetivada com sucesso! Novos saldos: Conta Origem: {1:F2} | Conta Destino: {2:F2}", correlationId, contaSaldoOrigem.GetSaldo(), contaSaldoDestino.GetSaldo());
        }
    }
}
