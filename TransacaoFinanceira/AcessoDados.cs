using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransacaoFinanceira
{
    public class AcessoDados : IRepositorioContas
    {
        private List<ContasSaldo> _tabelaSaldos;

        public AcessoDados()
        {
            _tabelaSaldos = new List<ContasSaldo>
            {
                new ContasSaldo(938485762, 180),
                new ContasSaldo(347586970, 1200),
                new ContasSaldo(2147483649, 0),
                new ContasSaldo(675869708, 4900),
                new ContasSaldo(238596054, 478),
                new ContasSaldo(573659065, 787),
                new ContasSaldo(210385733, 10),
                new ContasSaldo(674038564, 400),
                new ContasSaldo(563856300, 1200)
            };
        }

        public ContasSaldo GetRegistroConta(uint id)
        {
            return _tabelaSaldos.Find(x => x.GetConta() == id);
        }
    }
}