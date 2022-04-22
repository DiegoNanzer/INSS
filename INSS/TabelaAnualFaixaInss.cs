using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSS
{
    public class TabelaAnualFaixaInss
    {
        public readonly decimal FaixaDe;
        public readonly decimal FaixaAte;
        public readonly decimal Aliquota;

        public TabelaAnualFaixaInss(decimal faixaDe, decimal faixaAte, decimal aliquota)
        {
            ArgumentNullException.ThrowIfNull(faixaDe);
            ArgumentNullException.ThrowIfNull(faixaAte);
            ArgumentNullException.ThrowIfNull(aliquota);

            FaixaDe = faixaDe;
            FaixaAte = faixaAte;
            Aliquota = aliquota;
        }





    }
}
