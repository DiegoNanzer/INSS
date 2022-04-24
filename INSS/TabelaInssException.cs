using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSS
{
    public class TabelaInssException : Exception
    {
        public TabelaInssException(string message) : base(message)
        {
        }
    }
}
