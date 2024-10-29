using DigitalLibrary.WebApi.Dtos.Book;
using FluentValidation;

namespace DigitalLibrary.WebApi.Configurations.Validators
{
    public class BookDtoValidator : AbstractValidator<BookRequestDto>
    {
        public BookDtoValidator()
        {
            //RuleFor(dto => dto.Id).NotEmpty().GreaterThan(0);
            RuleFor(dto => dto.Title).NotEmpty().MaximumLength(255);
            RuleFor(dto => dto.Author).NotEmpty().MaximumLength(255);
            RuleFor(dto => dto.PublicationYear).NotEmpty();
            RuleFor(dto => dto.CoverImageUrl).MaximumLength(600);
            RuleFor(dto => dto.Rating);
            RuleFor(dto => dto.Review).MaximumLength(600);

        }
    }
}
