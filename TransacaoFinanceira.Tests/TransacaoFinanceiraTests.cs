using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransacaoFinanceira.Tests
{
    public class TransacaoFinanceiraTests
    {
        [Fact]
        public void Transferir_Valor_Quando_Saldo_Suficiente()
        {
            IRepositorioContas repositorio = new AcessoDados();
            IServicoTransacao executor = new ExecutarTransacaoFinanceira(repositorio);
            uint contaOrigem = 938485762; // Conta com saldo de 180
            uint contaDestino = 2147483649; // Conta com saldo de 0
            decimal valorTransferencia = 50;

            executor.Transferir(1, contaOrigem, contaDestino, valorTransferencia);

            var saldoOrigem = repositorio.GetRegistroConta(contaOrigem).GetSaldo();
            var saldoDestino = repositorio.GetRegistroConta(contaDestino).GetSaldo();

            Assert.Equal(130, saldoOrigem);
            Assert.Equal(50, saldoDestino);
        }

        [Fact]
        public void Cancelar_Transferencia_Quando_Saldo_Insuficiente()
        {
            IRepositorioContas repositorio = new AcessoDados();
            IServicoTransacao executor = new ExecutarTransacaoFinanceira(repositorio);
            uint contaOrigem = 210385733; // Conta com saldo de 10
            uint contaDestino = 238596054; // Conta com saldo de 478
            decimal valorTransferencia = 20;
                       
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                executor.Transferir(2, contaOrigem, contaDestino, valorTransferencia);

                var expectedMessage = "Transacao numero 2 foi cancelada por falta de saldo";
                var resultMessage = sw.ToString().Trim();

                Assert.Equal(expectedMessage, resultMessage);

                var saldoOrigem = repositorio.GetRegistroConta(contaOrigem).GetSaldo();
                var saldoDestino = repositorio.GetRegistroConta(contaDestino).GetSaldo();

                Assert.Equal(10, saldoOrigem);  // Saldo não deve mudar
                Assert.Equal(478, saldoDestino);  // Saldo não deve mudar
            }
        }

        [Fact]
        public void Verificar_Se_Conta_Origem_Existe()
        {
            IRepositorioContas repositorio = new AcessoDados();
            IServicoTransacao executor = new ExecutarTransacaoFinanceira(repositorio);
            uint contaOrigem = 0; // Conta inexistente
            uint contaDestino = 238596054; // Conta com saldo de 478
            decimal valorTransferencia = 20;

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                executor.Transferir(3, contaOrigem, contaDestino, valorTransferencia);

                var expectedMessage = "Transacao numero 3 foi cancelada: Conta de origem não existe";
                var resultMessage = sw.ToString().Trim();

                Assert.Equal(expectedMessage, resultMessage);

                var saldoDestino = repositorio.GetRegistroConta(contaDestino).GetSaldo();

                Assert.Equal(478, saldoDestino);  // Saldo não deve mudar
            }
        }

        [Fact]
        public void Verificar_Se_Conta_Destino_Existe()
        {
            IRepositorioContas repositorio = new AcessoDados();
            IServicoTransacao executor = new ExecutarTransacaoFinanceira(repositorio);
            uint contaOrigem = 210385733; // Conta com saldo de 478
            uint contaDestino = 0; // Conta inexistente
            decimal valorTransferencia = 20;

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                executor.Transferir(4, contaOrigem, contaDestino, valorTransferencia);

                var expectedMessage = "Transacao numero 4 foi cancelada: Conta de destino não existe";
                var resultMessage = sw.ToString().Trim();

                Assert.Equal(expectedMessage, resultMessage);

                var saldoOrigem = repositorio.GetRegistroConta(contaOrigem).GetSaldo();

                Assert.Equal(10, saldoOrigem);  // Saldo não deve mudar
            }
        }


    }
}
