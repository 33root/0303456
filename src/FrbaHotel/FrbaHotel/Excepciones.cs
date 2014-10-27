using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel
{
    class Excepciones : Exception
    {
        public Excepciones(string mensaje) : base(mensaje) { }
    }
}
