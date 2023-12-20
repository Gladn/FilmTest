using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmsTest.Model
{
    public class Actor
    {
        [Key]
        public int ActID { get; set; }
        public string ActName { get; set; }
    }

    public class FilmActor
    {
        public int ActID { get; set; }
        public int FmID { get; set; }


        [ForeignKey(nameof(FmID))]
        public Film Film { get; set; }

        [ForeignKey(nameof(ActID))]
        public Actor Actor { get; set; }
    }
}
