namespace DigitalLibrary.WebApi.Models
{
    public class Book
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Author { get; set; }
        public int PublicationYear { get; set; }
        public string CoverImageUrl { get; set; } // Optional
        public int Rating { get; set; } // Rating from 1 to 5
        public string Review { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
