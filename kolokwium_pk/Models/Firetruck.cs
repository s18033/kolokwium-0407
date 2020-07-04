using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium_pk.Models
{
    public class Firetruck
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdFiretruck { get; set; }

        [Required]
        [MaxLength(10)]
        public string OperationalNumber { get; set; }

        [Required]
        public bool SpecialEquipment { get; set; }
    }
}
