using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium_pk.DTOs
{
    public class FirefighterActionResponseDTO
    {
        public int IdAction { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
