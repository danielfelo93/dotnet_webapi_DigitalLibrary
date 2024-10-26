namespace DigitalLibrary.WebApi.Models
{
    public class User
    {
        public int UserId { get; set; }
        //public required string UserName { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string AspNetUserId { get; set; }
        public ApplicationUser AspNetUser { get; set; }
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
