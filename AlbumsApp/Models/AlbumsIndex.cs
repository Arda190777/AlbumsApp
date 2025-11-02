using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;  
using System.Linq;
namespace AlbumsApp.Models
{
    public class AlbumsIndex
    {
       
        public Genre? ActiveGenre {  get; set; }

        public IEnumerable<Album> Albums { get; set; } = Enumerable.Empty<Album>();

        public Album? Featured {  get; set; }

        public string? AlertMessage { get; set; }

        public NewAlbumInput NewAlbum { get; set; } = new();



    }


 public class NewAlbumInput
    {

       
        public string Title { get; set; } = string.Empty;

        [Required, StringLength(100)]
        public string Artist { get; set; } = string.Empty;

        [Required, Range(1900, 2100)]
        public int Year { get; set; }

        [Required]
        public Genre? Genre { get; set; }
        [Required, Url]
        [Display(Name = "Cover Image Url")]
        public string CoverImageUrl { get; set; } = string.Empty;

        public Genre? CurrentGenre { get; set; }














    }
}
