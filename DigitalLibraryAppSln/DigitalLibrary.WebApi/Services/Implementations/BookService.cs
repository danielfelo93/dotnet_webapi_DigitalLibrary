using AutoMapper;
using Azure.Core;
using DigitalLibrary.WebApi.Dtos.Book;
using DigitalLibrary.WebApi.Models;
using DigitalLibrary.WebApi.Repositories.Contracts;
using DigitalLibrary.WebApi.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace DigitalLibrary.WebApi.Services.Implementations
{
    public class BookService : IBookService
    {
        private readonly IBaseRepository<Book> _bookRepository;
        private readonly IMapper _mapper;
        public BookService(IBaseRepository<Book> bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }
        public async Task<BookResponseDto> Add(BookRequestDto request)
        {
            //var books = await _bookRepository.FindBy(x => x.Id == id).FirstOrDefaultAsync();
            var books = new Book();
            books.Title = request.Title;
            books.Author = request.Author;
            books.PublicationYear = request.PublicationYear;
            books.CoverImageUrl = request.CoverImageUrl;
            books.Rating = request.Rating;
            books.Review = request.Review;
            books.UserId = request.UserId;

            await _bookRepository.Delete(books);
            var response = _mapper.Map<BookResponseDto>(books);
            return response;
        }

        public async Task<BookResponseDto> Delete(int id)
        {
            var books = await _bookRepository.FindBy(x => x.Id == id).FirstOrDefaultAsync();

            await _bookRepository.Delete(books);
            var response = _mapper.Map<BookResponseDto>(books);
            return response;
        }

        public async Task<IEnumerable<BookResponseDto>> GetAll()
        {
            var books = await _bookRepository.GetAll().AsNoTracking().ToListAsync();
            var response = _mapper.Map<IEnumerable<BookResponseDto>>(books);
            return response;
        }

        public async Task<BookResponseDto> GetById(int id)
        {
            var books = await _bookRepository.FindByAsNoTracking(x => x.Id==id).FirstOrDefaultAsync();
            var response = _mapper.Map<BookResponseDto>(books);
            return response;
        }

        public async Task<BookResponseDto> Update(BookRequestDto request, int id)
        {
            var books = await _bookRepository.FindBy(x => x.Id == id).FirstOrDefaultAsync();
            books.Title = request.Title;
            books.Author = request.Author;
            books.PublicationYear = request.PublicationYear;
            books.CoverImageUrl = request.CoverImageUrl;
            books.Rating = request.Rating;
            books.Review = request.Review;
            books.UserId = request.UserId;

            await _bookRepository.Update(books);
            var response = _mapper.Map<BookResponseDto>(books);
            return response;
        }
    }
}
