namespace FilmsTest.DTOs
{
    public class GenreDTO
    {
        public int GenID { get; set; }
        public string GenName { get; set; }
    }

    public class FilmGenreDTO
    {
        public int GenID { get; set; }
        public int FmID { get; set; }
    }
}
