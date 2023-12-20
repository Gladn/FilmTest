using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmsTest.Model
{
    public class Genre
    {
        [Key]
        public int GenID { get; set; }
        public string GenName { get; set; }
    }

    public class FilmGenre
    {
        public int GenID { get; set; }
        public int FmID { get; set; }


        [ForeignKey(nameof(FmID))]
        public Film Film { get; set; }

        [ForeignKey(nameof(GenID))]
        public Genre Genre { get; set; }
    }
}
