namespace Application.DTOs
{
    public class FicheAbsenceDTO
    {
        public int CodeFicheAbsence { get; set; }
        public DateTime DateJour { get; set; }
        public int CodeMatiere { get; set; }
        public int CodeEnseignant { get; set; }
        public int CodeClasse { get; set; }
    }
}