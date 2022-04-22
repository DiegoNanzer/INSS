using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSS
{
    public class CalculadorInss : ICalculadorInss
    {
        private IEnumerable<TabelaAnualInss> _tabelasInss { get; set; }

        public CalculadorInss(IEnumerable<TabelaAnualInss> tabelasInss)
        {
            ArgumentNullException.ThrowIfNull(tabelasInss);

            _tabelasInss = tabelasInss;
        }

        public decimal CalcularDesconto(DateTime data, decimal salario)
        {
            var tabela = _tabelasInss.FirstOrDefault(x => x.AnoReferencia == data.Year);

            if (tabela is null)
                throw new TabelaInnsException($"Tabela do INSS referente ao ano '{data.Year} não informada");

            var faixa = tabela.Faixas.FirstOrDefault(x => salario >= x.FaixaDe && salario <= x.FaixaAte);

            if (faixa is null)
                return tabela.Teto;

            var desconto = salario * faixa.Aliquota / 100;

            return Math.Round(desconto, 2);
        }
    }
}
