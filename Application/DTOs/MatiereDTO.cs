namespace Application.DTOs
{
    public class MatiereDTO
    {
        public int CodeMatiere { get; set; }
        public string? NomMatiere { get; set; }
        public int NbreHeureCoursParSemaine { get; set; }
        public int NbreHeureTDParSemaine { get; set; }
        public int NbreHeureTPParSemaine { get; set; }
    }
}