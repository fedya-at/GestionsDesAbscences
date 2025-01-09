using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Seance
    {
        [Key]
        public int CodeSeance { get; set; }

        [Required]
        [StringLength(100)]
        public string? NomSeance { get; set; }

        [Required]
        public TimeSpan HeureDebut { get; set; }

        [Required]
        public TimeSpan HeureFin { get; set; }
        public ICollection<FicheAbsenceSeance> FicheAbsenceSeances { get; set; }

    }
}
