namespace Application.DTOs
{
    public class SeanceDTO
    {
        public int CodeSeance { get; set; }
        public string? NomSeance { get; set; }
        public TimeSpan HeureDebut { get; set; }
        public TimeSpan HeureFin { get; set; }
    }
}