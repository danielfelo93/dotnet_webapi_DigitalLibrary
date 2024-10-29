using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DigitalLibrary.WebApi.Models
{
    public class Book : BaseTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublicationYear { get; set; }
        public string CoverImageUrl { get; set; } // Optional
        public int Rating { get; set; } // Rating from 1 to 5
        public string Review { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
