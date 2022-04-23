using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace INSS.Test
{
    public class CalculadoraInssTest
    {
        private readonly List<TabelaAnualInss> _listaTabelaINSS;

        public CalculadoraInssTest()
        {
            _listaTabelaINSS = new List<TabelaAnualInss>
            {
                new TabelaAnualInss(anoReferencia: 2011, teto: 405.86M, faixas: new List<TabelaAnualFaixaInss>
                {
                    new TabelaAnualFaixaInss(faixaDe: 0, faixaAte: 1106.90M,aliquota: 8M),
                    new TabelaAnualFaixaInss(faixaDe: 1106.91M,faixaAte: 1844.83M, aliquota: 9M),
                    new TabelaAnualFaixaInss(faixaDe: 1844.84M,faixaAte: 3689.66M, aliquota:11M),
                }),
                new TabelaAnualInss(anoReferencia: 2012, teto: 500M, faixas: new List<TabelaAnualFaixaInss>
                {
                    new TabelaAnualFaixaInss(faixaDe: 0, faixaAte: 1000.00M,aliquota: 7M),
                    new TabelaAnualFaixaInss(faixaDe: 1000.01M,faixaAte: 1500.00M, aliquota: 8M),
                    new TabelaAnualFaixaInss(faixaDe: 1500.01M,faixaAte: 3000.00M, aliquota: 9M),
                    new TabelaAnualFaixaInss(faixaDe: 3000.01M,faixaAte: 4000.00M, aliquota: 11M),
                }),
                new TabelaAnualInss(anoReferencia: 2013, teto: 600M, faixas: new List<TabelaAnualFaixaInss>
                {
                    new TabelaAnualFaixaInss(faixaDe: 0, faixaAte: Decimal.MaxValue,aliquota: 10M)
                }),
            };
        }

        [Theory]
        [InlineData(2012, 4000.01, 500.00)]
        [InlineData(2012, 6000.00, 500.00)]
        public void CalcularDesconto_Deve_Calcular_Desconto_Teto(int ano, decimal salario, decimal teto)
        {
            #region Arrange
            ICalculadorInss act = new CalculadorInss(_listaTabelaINSS);
            DateTime data = new DateTime(ano, 1, 1);

            #endregion

            #region Act

            decimal desconto = act.CalcularDesconto(data, salario);

            #endregion

            #region Assert

            desconto.Should().Be(teto);

            #endregion
        }

        [Theory]
        [InlineData(2011, 1000, 80)]
        [InlineData(2011, 4000, 405.86)]
        [InlineData(2011, 1844.83, 166.03)]
        [InlineData(2012, 1500.01, 135.00)]
        [InlineData(2013, 1000.00, 100.00)]
        public void CalcularDesconto_Deve_Calcular_Desconto(int ano, decimal salario, decimal teto)
        {
            #region Arrange
            ICalculadorInss act = new CalculadorInss(_listaTabelaINSS);
            DateTime data = new DateTime(ano, 1, 1);

            #endregion

            #region Act

            decimal desconto = act.CalcularDesconto(data, salario);

            #endregion

            #region Assert

            desconto.Should().Be(teto);

            #endregion
        }

        [Fact]
        public void CalcularDesconto_Deve_Lancar_Exception_Quanto_Tabela_NaoExiste()
        {
            #region Arrange
            ICalculadorInss act = new CalculadorInss(_listaTabelaINSS);
            DateTime data = DateTime.MinValue;
            decimal salario = 1000M;

            #endregion

            #region Act

            var funcAct = () => act.CalcularDesconto(data, salario);

            #endregion

            #region Assert

            funcAct.Should().Throw<TabelaInnsException>();

            #endregion
        }

    }
}
