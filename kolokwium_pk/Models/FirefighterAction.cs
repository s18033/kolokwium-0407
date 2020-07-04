using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kolokwium_pk.Models
{
    public class FirefighterAction
    {
        [ForeignKey("Action")]
        public int IdAction { get; set; }

        [ForeignKey("Firefighter")]
        public int IdFirefighter { get; set; }
    }
}
