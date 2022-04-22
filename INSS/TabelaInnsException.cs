using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSS
{
    public class TabelaInnsException : Exception
    {
        public TabelaInnsException(string message) : base(message)
        {
        }
    }
}
