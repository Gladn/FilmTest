namespace FilmsTest.DTOs
{
    public class ActorDTO
    {
        public int ActID { get; set; }
        public string ActName { get; set; }
    }

    public class FilmActorDTO
    {
        public int ActID { get; set; }
        public int FmID { get; set; }
    }
}
