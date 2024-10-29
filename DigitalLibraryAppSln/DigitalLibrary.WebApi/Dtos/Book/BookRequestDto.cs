namespace DigitalLibrary.WebApi.Dtos.Book
{
    public class BookRequestDto
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublicationYear { get; set; }
        public string CoverImageUrl { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }
        public int UserId { get; set; }

    }
}
