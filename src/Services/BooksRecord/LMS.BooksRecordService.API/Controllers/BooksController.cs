using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMS.BooksRecordService.API.Application.Commands;
using LMS.BooksRecordService.API.Application.DTOs;
using LMS.BooksRecordService.API.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LMS.BooksRecordService.API.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddBookAsync(UpsertBookCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateBookAsync(int bookId, UpsertBookCommand command)
        {
            command.SetId(bookId);
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("all")]
        public async Task<List<BookDTO>> GetBooksAsync(GetAllBookQuery query)//paged list m convrt krna
        {
            var books = await _mediator.Send(query);
            return books;
        }
        [HttpGet("one")]

        public async Task<IActionResult> GetBooks(string bookId)
        {
            if (string.IsNullOrEmpty(bookId))
            {
                return BadRequest("BookId is required.");
            }

            var query = new GetBookByIdQuery { BookId = bookId };
            var book = await _mediator.Send(query);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpDelete]
        public async Task<string> DeleteBookByIdAsync(int bookId)
        {
            var command = new DeleteBookCommand { BookId = bookId };
            return await _mediator.Send(command);
        }
    }
}
