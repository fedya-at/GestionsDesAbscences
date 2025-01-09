using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class FicheAbsenceSeance
    {
        [Key, Column(Order = 1)]
        [ForeignKey("FicheAbsence")]
        public int CodeFicheAbsence { get; set; }

        [Key, Column(Order = 2)]
        [ForeignKey("Seance")]
        public int CodeSeance { get; set; }

        // Navigation properties
        public FicheAbsence FicheAbsence { get; set; }
        public Seance Seance { get; set; }
    }
}
