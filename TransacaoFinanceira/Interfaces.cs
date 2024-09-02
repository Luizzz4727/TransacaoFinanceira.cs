using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransacaoFinanceira
{
    public interface IRepositorioContas
    {
        ContasSaldo GetRegistroConta(uint id);
    }

    public interface IServicoTransacao
    {
        void Transferir(int correlationId, uint contaOrigem, uint contaDestino, decimal valor);
    }
}
