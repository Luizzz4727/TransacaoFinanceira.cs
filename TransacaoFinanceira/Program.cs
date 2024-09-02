using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransacaoFinanceira
{
    class Program
    {
        static void Main(string[] args)
        {
            var transacoes = new[] {
                new Transacao { correlation_id = 1, datetime = "09/09/2023 14:15:00", conta_origem = 938485762, conta_destino = 2147483649, VALOR = 150 },
                new Transacao { correlation_id = 2, datetime = "09/09/2023 14:15:05", conta_origem = 2147483649, conta_destino = 210385733, VALOR = 149 },
                new Transacao { correlation_id = 3, datetime = "09/09/2023 14:15:29", conta_origem = 347586970, conta_destino = 238596054, VALOR = 1100 },
                new Transacao { correlation_id = 4, datetime = "09/09/2023 14:17:00", conta_origem = 675869708, conta_destino = 210385733, VALOR = 5300 },
                new Transacao { correlation_id = 5, datetime = "09/09/2023 14:18:00", conta_origem = 238596054, conta_destino = 674038564, VALOR = 1489 },
                new Transacao { correlation_id = 6, datetime = "09/09/2023 14:18:20", conta_origem = 573659065, conta_destino = 563856300, VALOR = 49 },
                new Transacao { correlation_id = 7, datetime = "09/09/2023 14:19:00", conta_origem = 938485762, conta_destino = 2147483649, VALOR = 44 },
                new Transacao { correlation_id = 8, datetime = "09/09/2023 14:19:01", conta_origem = 573659065, conta_destino = 675869708, VALOR = 150 },
                new Transacao { correlation_id = 9, datetime = "09/09/2023 14:19:02", conta_origem = 0, conta_destino = 675869708, VALOR = 47 },
                new Transacao { correlation_id = 10, datetime = "09/09/2023 14:19:03", conta_origem = 573659065, conta_destino = 0, VALOR = 27 },
                new Transacao { correlation_id = 11, datetime = "09/09/2023 14:19:04", conta_origem = 675869708, conta_destino = 573659065, VALOR = 20.09M }
            };

            IRepositorioContas repositorio = new AcessoDados();
            IServicoTransacao executor = new ExecutarTransacaoFinanceira(repositorio);

            foreach (var item in transacoes)
            {
                executor.Transferir(item.correlation_id, item.conta_origem, item.conta_destino, item.VALOR);
            }
        }
    }
}
