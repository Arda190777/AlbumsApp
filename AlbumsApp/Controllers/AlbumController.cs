using AlbumsApp.Models;
using AlbumsApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace AlbumsApp.Controllers
{
    public class AlbumController : Controller
    {
        private readonly IAlbumService _albumService;

        public AlbumController(IAlbumService albumService)
        {

            _albumService = albumService;
        }

        public IActionResult Index(Genre? genre)
        {
            var albums = genre.HasValue
                ? _albumService.GetByGenre(genre.Value)
                : _albumService.GetAll();
            var viewmModel = new AlbumsIndex
            {

                Albums = albums,
                ActiveGenre = genre,
                Featured = _albumService.GetRandom(),
                AlertMessage = TempData["AlertMessage"] as string,
                NewAlbum = new NewAlbumInput
                {
                    CurrentGenre = genre,
                }

            };
            
            return View(viewmModel);
        }

        [HttpPost("/Albulms/Create")]
        public IActionResult AddAlbum(NewAlbumInput newAlbum)
        {

            if(ModelState.IsValid)

            {
                var album = new Album
                {
                    Title = newAlbum.Title,
                    Artist = newAlbum.Artist,       
                    Year = newAlbum.Year,
                    Genre = newAlbum.Genre,
                    CoverImageUrl = newAlbum.CoverImageUrl,

                };

                _albumService.Add(album);
                TempData["AlertMessage"] = "Album added";  
                return RedirectToAction("Index", new {genre = newAlbum.CurrentGenre});

            }

           var albums = newAlbum.CurrentGenre.HasValue
           ? _albumService.GetByGenre(newAlbum.CurrentGenre.Value)
           : _albumService.GetAll();

            var viewModel = new AlbumsIndex
            {
                Albums = albums,
                ActiveGenre = newAlbum.CurrentGenre,
                Featured = _albumService.GetRandom(),
                NewAlbum = newAlbum,
            };
            return View("Index", viewModel);

        }
        [HttpGet("/Albulms/Details/{id}")]
        public IActionResult Details(int id)
        {

            var album = _albumService.GetById(id);

            if(album == null)
            {
                return NotFound();

            }
            return View(album);
        }

       
                

    }
}
