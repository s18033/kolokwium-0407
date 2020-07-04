using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium_pk.Models
{
    public class FiretruckAction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdFiretruckAction { get; set; }

        [ForeignKey("Action")]
        public int IdAction { get; set; }

        [ForeignKey("Firetruck")]
        public int IdFiretruck { get; set; }

        [Required]
        public DateTime AssignmentDate { get; set; }
    }
}
