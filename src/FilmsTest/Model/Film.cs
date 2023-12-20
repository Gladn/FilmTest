using System.ComponentModel.DataAnnotations;

namespace FilmsTest.Model
{
    public class Film
    {
        [Key]
        public int FmID { get; set; }
        public string? FmTitle { get; set; }
        public int FmYear { get; set; }
    }
}
