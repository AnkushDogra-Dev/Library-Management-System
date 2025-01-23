using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.BooksRecordService.API.Application.DTOs
{
    [SuppressMessage(
        "Maintainability",
        "S101",
        Justification = "Need to Suppress we cannot change the value."
    )]
    public class BookDTO
    {
        public Guid BookId { get; init; }
        public string Title { get; init; } = "";
        public string Author { get; init; } = "";
        public string ISBN { get; init; } = "";
        public string Publisher { get; init; } = "";
        public DateTime PublicationDate { get; init; }
        public int AvailableCopies { get; init; }
        public int NumberOfCopies { get; init; }
        public string ShelfLocation { get; init; } = "";
        public string Status { get; init; } = ""; // iska enum banana he mene.
    }
}
