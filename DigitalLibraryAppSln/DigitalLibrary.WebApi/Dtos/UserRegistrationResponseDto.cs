namespace DigitalLibrary.WebApi.Dtos
{
    public class UserRegistrationResponseDto
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public bool IsSuccess { get; set; }
    }
}
