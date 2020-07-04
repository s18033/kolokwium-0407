using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium_pk.Services
{
    public class FirefightersException : Exception
    {
        public FirefightersException(string message) : base(message)
        {
        }
    }
}
