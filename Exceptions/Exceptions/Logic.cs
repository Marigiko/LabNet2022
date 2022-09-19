using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    internal class Logic
    {
        public void ExpresionInvalida()
        {
            throw new InvalidExpressionException();
        }

        public void ExcepcionPersonalizada(String mensaje)
        {
            throw new CustomExcepcion(mensaje);
        }
    }
}
