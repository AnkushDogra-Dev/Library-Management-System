using LMS.Application.Common.Exceptions;
using LMS.BooksRecordService.API.Application.DTOs;
using LMS.BooksRecordService.API.Entities;
using LMS.BooksRecordService.API.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LMS.BooksRecordService.API.Application.Commands
{
    public record UpsertBookCommandHandler : IRequestHandler<UpsertBookCommand, int>
    {
        private readonly BooksDbContext _dbContext;

        public UpsertBookCommandHandler(BooksDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(UpsertBookCommand request, CancellationToken cancellationToken)
        {
            Book book;
            if (request.BookId > 0)
            {
                book = await _dbContext.Books.FirstOrDefaultAsync(b => b.Id == request.BookId, cancellationToken)
                ?? throw new NotFoundException(nameof(Book), request.BookId);


                book.UpdateBookDetails(request.Title, request.Author, request.ISBN, request.Publisher, request.PublicationDate, request.AvailableCopies,
                                        request.NumberOfCopies, request.ShelfLocation, request.Status
                );

                await _dbContext.SaveChangesAsync(cancellationToken);
            }
            else
            {
                book = new Book(request.Title, request.Author, request.ISBN, request.Publisher, request.PublicationDate, request.AvailableCopies, request.NumberOfCopies, request.ShelfLocation, request.Status);

                _dbContext.Books.Add(book);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }

            return book.Id;
        }
    }
}