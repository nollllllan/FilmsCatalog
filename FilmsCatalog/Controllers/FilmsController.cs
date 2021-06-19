using AutoMapper;
using FilmsCatalog.Data.Repositories.Interfaces;
using FilmsCatalog.Extensions;
using FilmsCatalog.Models;
using FilmsCatalog.Models.ViewModels.Film;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using X.PagedList;

namespace FilmsCatalog.Controllers
{
    [Authorize]
    public class FilmsController : Controller
    {
        private readonly IFilmRepository _filmRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public FilmsController(IFilmRepository filmRepository, IMapper mapper, UserManager<User> userManager)
        {
            _filmRepository = filmRepository;
            _mapper = mapper;
            _userManager = userManager;
        }
        
        public  IActionResult Index(int? page)
        {
            var pageNumber = page ?? 1;
            var pagedList = _filmRepository.GetAll().ToPagedList(pageNumber, 8);
            
            ViewBag.OnePageOfFilms = pagedList.ToMappedPagedList<Film, FilmsViewModel>(_mapper);
            
            return View();
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = await _filmRepository.Get(id.Value);
            if (film == null)
            {
                return NotFound();
            }

            var mapResult = _mapper.Map<FilmDetailsViewModel>(film);

            return View(mapResult);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateFilmViewModel filmView)
        {
            if (!ModelState.IsValid) return View(filmView);

            var film = _mapper.Map<Film>(filmView);
            film.User = await _userManager.GetUserAsync(User);

            await _filmRepository.Create(film);
            
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = await _filmRepository.Get(id.Value);
            if (film == null || film.User.Id != _userManager.GetUserId(User))
            {
                return NotFound();
            }

            var mapResult = _mapper.Map<EditFilmViewModel>(film);

            return View(mapResult);
        }

        [ValidateAntiForgeryToken, HttpPost]
        public async Task<IActionResult> Edit(int id, EditFilmViewModel filmViewModel)
        {
            if (id != filmViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid && (filmViewModel.Poster?.ContentType.Contains("image") ?? true))
            {
                var film = _mapper.Map<Film>(filmViewModel);
                await _filmRepository.Update(film);
            
                return RedirectToAction(nameof(Index));
            }
            
            return View(filmViewModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = await _filmRepository.Get(id.Value);
            if (film == null)
            {
                return NotFound();
            }

            await _filmRepository.Delete(film);

            return RedirectToAction(nameof(Index));
        }
    }
}
