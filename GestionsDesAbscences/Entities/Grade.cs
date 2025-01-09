using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Grade
    {
        [Key]
        public int CodeGrade { get; set; }

        [Required]
        [StringLength(100)]
        public string? NomGrade { get; set; }
    }
}
