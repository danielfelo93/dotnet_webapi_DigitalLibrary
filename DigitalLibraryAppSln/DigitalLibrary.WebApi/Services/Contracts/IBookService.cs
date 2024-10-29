using DigitalLibrary.WebApi.Dtos.Book;

namespace DigitalLibrary.WebApi.Services.Contracts
{
    public interface IBookService
    {
        Task<IEnumerable<BookResponseDto>> GetAll();
        Task<BookResponseDto> GetById(int id);
        Task<BookResponseDto> Add(BookRequestDto request);
        Task<BookResponseDto> Update(BookRequestDto request, int id);
        Task<BookResponseDto> Delete(int id);
    }
}
