using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Matiere
    {
        [Key]
        public int CodeMatiere { get; set; }

        [Required]
        [StringLength(100)]
        public string? NomMatiere { get; set; }

        [Range(0, 40)]
        public int NbreHeureCoursParSemaine { get; set; }

        [Range(0, 40)]
        public int NbreHeureTDParSemaine { get; set; }

        [Range(0, 40)]
        public int NbreHeureTPParSemaine { get; set; }
    }
}
