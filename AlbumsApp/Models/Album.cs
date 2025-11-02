using System.ComponentModel.DataAnnotations;

namespace AlbumsApp.Models
{
    public class Album
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required, StringLength(100)]
        public string Artist { get; set; } = string.Empty;

        [Required, Range(1900, 2100)]
        public int Year { get; set; }

        [Required]
        public Genre? Genre { get; set; }

        [Required, Url]
        [Display(Name = "Cover Image URL")]
        public string CoverImageUrl { get; set; } = string.Empty;

        public string Summary => $"\"{Title}\" by {Artist} ({Year})";
    }
}
