using DigitalLibrary.WebApi.Dtos.Book;
using DigitalLibrary.WebApi.Services.Contracts;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigitalLibrary.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IValidator<BookRequestDto> _validator;
        private readonly IBookService _bookService;
        public BookController(IBookService bookService, IValidator<BookRequestDto> validator)
        {
            _bookService = bookService;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = await _bookService.GetAll();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var books = await _bookService.GetById(id);
            return Ok(books);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookRequestDto bookDto)
        {
            var validationResult = await _validator.ValidateAsync(bookDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var books = await _bookService.Add(bookDto);
            return Ok(books);
        }

    }
}
