using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Groupe
    {
        [Key]
        public int CodeGroupe { get; set; }

        [Required]
        [StringLength(100)]
        public string? GroupeName { get; set; }
    }
}
