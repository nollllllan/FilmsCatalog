using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace FilmsCatalog.Models.ViewModels.Film
{
    public class CreateFilmViewModel
    {
        [Required(ErrorMessage = "Введите имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите описание")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Введите фамилию режиссера")]
        public string ProducerSecondName { get; set; }

        [Required(ErrorMessage = "Введите год"), Range(1895, 2100, ErrorMessage = "Некорректный год, значение должно быть от 1895 до 2100")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Загрузите файл постера"), DataType(DataType.Upload)]
        public IFormFile Poster { get; set; }
    }
}