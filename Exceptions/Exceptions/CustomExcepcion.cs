﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    internal class CustomExcepcion : Exception
    {
        public CustomExcepcion(String mensaje) : base(mensaje)
        {
        }
    }
}
