namespace FilmsCatalog.Models.ViewModels.Film
{
    public class FilmsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProducerSecondName { get; set; }
        public int Year { get; set; }
        public string UserId { get; set; }
        public string UserFullName { get; set; }
    }
}