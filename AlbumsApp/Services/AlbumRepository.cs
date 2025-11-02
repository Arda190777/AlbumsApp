  using System;                  
  using System.Collections.Generic; 
  using System.Linq;             
  using AlbumsApp.Models;

namespace AlbumsApp.Services
    {
        public class AlbumRepository : IAlbumService
        {
            private readonly List<Album> _albums;
            private int next_Id = 1;
            private readonly Random _random = new();

            public AlbumRepository()
            {
                _albums = new List<Album>
                {
                   new Album { Id = next_Id++, Title = "Let It Be", Artist = "The Beatles", Year = 1970, Genre = Genre.Rock,
                   CoverImageUrl = "https://upload.wikimedia.org/wikipedia/en/7/7a/The_Beatles_-_Let_It_Be.png" },   

                   new Album { Id = next_Id++, Title = "Nevermind", Artist = "Nirvana", Year = 1991, Genre = Genre.Rock,
                   CoverImageUrl = "https://upload.wikimedia.org/wikipedia/en/b/b7/NirvanaNevermindalbumcover.jpg" }, 

                   new Album { Id = next_Id++, Title = "The Freewheelin' Bob Dylan", Artist = "Bob Dylan", Year = 1963, Genre = Genre.Folk,
                   CoverImageUrl = "https://upload.wikimedia.org/wikipedia/en/d/d6/Bob_Dylan_-_The_Freewheelin%27_Bob_Dylan.jpg" },  

                   new Album { Id = next_Id++, Title = "Kind of Blue", Artist = "Miles Davis", Year = 1959, Genre = Genre.Classical,
                   CoverImageUrl = "https://upload.wikimedia.org/wikipedia/commons/a/ad/Kind_of_Blue_(1959,_CL_1355)_album_cover.jpg" }, 

                   new Album { Id = next_Id++, Title = "The Marshall Mathers LP", Artist = "Eminem", Year = 2000, Genre = Genre.Rap,
                   CoverImageUrl = "https://upload.wikimedia.org/wikipedia/en/a/ae/The_Marshall_Mathers_LP.jpg" } 

                




                };

           



            }
            public IEnumerable<Album> GetAll() => _albums;
            public IEnumerable<Album> GetByGenre(Genre genre) => _albums.Where(x => x.Genre == genre);
            public Album? GetById(int id ) => _albums.FirstOrDefault(x => x.Id == id);
            public Album Add(Album album)
            {
                album.Id = next_Id++;
                _albums.Add(album);
                return album;



            }

        public IEnumerable<Genre> AllGenres() => Enum.GetValues(typeof(Genre)).Cast<Genre>();
            
    

        public Album? GetRandom()
        {
            return _albums.Count == 0 ? null : _albums[_random.Next(_albums.Count)];
        }

       
    }


    }
