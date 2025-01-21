// using LMS.BooksRecordService.API.Application.DTOs;
// using MediatR;
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;

// namespace LMS.BooksRecordService.API.Application.Commands
// {
//     public record UpsertBookCommandHandler : IRequestHandler<UpsertBookCommand,string>
//     {
//         private readonly ApplicationDbContext _dbContext;

//         public UpsertBookCommandHandler(ApplicationDbContext dbContext)
//         {
//             _dbContext = dbContext;
//         }

//         public async Task Handle(UpsertBookCommand command, CancellationToken cancellationToken)
//         {
//             if (command.BookId.HasValue)
//             {
//                 var existingBook = await _dbContext.Books
//                     .FirstOrDefaultAsync(b => b.BookId == command.BookId.Value, cancellationToken);

//                 if (existingBook != null)
//                 {
//                     existingBook.UpdateBookDetails(
//                         command.Title,
//                         command.Author,
//                         command.ISBN,
//                         command.Publisher,
//                         command.PublicationDate,
//                         command.AvailableCopies,
//                         command.NumberOfCopies,
//                         command.ShelfLocation,
//                         command.Status
//                     );

//                     await _dbContext.SaveChangesAsync(cancellationToken);
//                 }
//                 else
//                 {
//                     throw new InvalidOperationException("Book not found.");
//                 }
//             }
//             else
//             {
//                 var newBook = new Book(
//                     Guid.NewGuid(), 
//                     command.Title,
//                     command.Author,
//                     command.ISBN,
//                     command.Publisher,
//                     command.PublicationDate,
//                     command.NumberOfCopies,
//                     command.ShelfLocation
//                 );

//                 await _dbContext.Books.AddAsync(newBook, cancellationToken);
//                 await _dbContext.SaveChangesAsync(cancellationToken);
//             }
//         }
//     }
// }