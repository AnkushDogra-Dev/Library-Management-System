using LMS.BooksRecordService.API.Application.DTOs;
using MediatR;
using System;
using System.Text.Json.Serialization;


namespace LMS.BooksRecordService.API.Application.Commands
{
    public record UpsertBookCommand : IRequest<int>
    {
        [JsonIgnore]
        public int BookId { get; set; }
        public string? Title { get; init; }
        public string? Author { get; init; }
        public string? ISBN { get; init; }
        public string? Publisher { get; init; }
        public DateTime PublicationDate { get; init; }
        public int AvailableCopies { get; init; }
        public int NumberOfCopies { get; init; }
        public string? ShelfLocation { get; init; }
        public string? Status { get; init; } 

        public void SetId(int bookId) {
            BookId = bookId;
        }
    }
}