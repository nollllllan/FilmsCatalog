using AutoMapper;
using FilmsCatalog.Extensions;
using FilmsCatalog.Models;
using FilmsCatalog.Models.ViewModels.Film;
using System;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace FilmsCatalog.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Film, FilmsViewModel>().ForMember(dest => dest.UserId,
                    opt => opt.MapFrom(x => x.User.Id))
                .ForMember(dest => dest.UserFullName,
                    opt => opt.MapFrom(x => $"{x.User.FirstName} {x.User.MiddleName} {x.User.LastName}"));

            CreateMap<CreateFilmViewModel, Film>().ForMember(dest => dest.Poster, 
                opt => opt.MapFrom(x => x.Poster.GetBytes()));            
            
            CreateMap<Film, FilmDetailsViewModel>().ForMember(dest => dest.Poster, 
                opt => opt.MapFrom(x => $"data:image;base64,{Convert.ToBase64String(x.Poster, 0, x.Poster.Length)}"));
            
            CreateMap<EditFilmViewModel, Film>().ForMember(dest => dest.Poster,
                opt => opt.MapFrom(x => x.Poster.GetBytes()));

            CreateMap<Film, EditFilmViewModel>().ForMember(x => x.Poster, opt => 
                opt.MapFrom(x => new FormFile(new MemoryStream(x.Poster), 0, x.Poster.Length, x.Name, x.Name + ".jpg")));
        }
    }
}