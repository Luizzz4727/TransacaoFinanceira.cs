using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransacaoFinanceira
{
    public class Transacao
    {
        public int correlation_id { get; set; }
        public string datetime { get; set; }
        public uint conta_origem { get; set; }
        public uint conta_destino { get; set; }
        public decimal VALOR { get; set; }
    }
}
