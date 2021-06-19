using System.ComponentModel.DataAnnotations.Schema;

namespace FilmsCatalog.Models
{
    public class Film
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProducerSecondName { get; set; }
        public int Year { get; set; }
        public byte[] Poster { get; set; }
        public string UserId { get; set; }
        
        [NotMapped, ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}