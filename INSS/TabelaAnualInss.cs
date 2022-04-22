using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSS
{
    public class TabelaAnualInss
    {
        public readonly int AnoReferencia;
        public readonly decimal Teto;
        public readonly IEnumerable<TabelaAnualFaixaInss> Faixas;

        public TabelaAnualInss(int anoReferencia, decimal teto, IEnumerable<TabelaAnualFaixaInss> faixas)
        {
            ArgumentNullException.ThrowIfNull(anoReferencia);
            ArgumentNullException.ThrowIfNull(teto);
            ArgumentNullException.ThrowIfNull(faixas);

            if (!faixas.Any())
                throw new ArgumentException("Faixa da tabela do INSS não informada");

            AnoReferencia = anoReferencia;
            Teto = teto;
            Faixas = faixas;
        }
    }
}
