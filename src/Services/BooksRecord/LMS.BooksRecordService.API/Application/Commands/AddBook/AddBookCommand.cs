using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.BooksRecordService.API.Application.Commands
{
    public class AddBookCommand
    {
        public string BookId { get; init; }
        public string Title { get; init; }
        public string Author { get; init; }
        public string ISBN { get; init; }
        public string Publisher { get; init; }
        public DateTime PublicationDate { get; init; }
        public int TotalCopies { get; init; }
        public string ShelfLocation { get; init; }
        public string Language { get; init; }
        public string Description { get; init; }
    }
}