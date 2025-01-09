using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Departement
    {
        [Key]
        public int CodeDepartement { get; set; }

        [Required]
        [StringLength(100)]
        public string? NomDepartement { get; set; }

    }
}
