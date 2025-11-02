using AlbumsApp.Models;

namespace AlbumsApp.Services
{
    public interface IAlbumService
    {
        IEnumerable<Album> GetAll();
        IEnumerable<Album> GetByGenre(Genre genre);
        Album Add(Album album);
        Album? GetById (int id);
        IEnumerable<Genre> AllGenres();
        Album? GetRandom();


    }
}
