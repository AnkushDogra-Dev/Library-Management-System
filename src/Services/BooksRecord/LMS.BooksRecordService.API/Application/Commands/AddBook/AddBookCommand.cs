// using LMS.BooksRecordService.API.Application.DTOs;
// using MediatR;
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;

// namespace LMS.BooksRecordService.API.Application.Commands
// {
//     public record UpsertBookCommand : IRequest<string>
//     {
//         public Guid BookId { get; set; }
//         public string Title { get; set; }
//         public string Author { get; set; }
//         public string ISBN { get; set; }
//         public string Publisher { get; set; }
//         public DateTime PublicationDate { get; set; }
//         public int AvailableCopies { get; set; }
//         public int NumberOfCopies { get; set; }
//         public string ShelfLocation { get; set; }
//         public string Status { get; set; } // This is a string, but you can use an enum if needed
//     }
// }