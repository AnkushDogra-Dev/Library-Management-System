using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace LMS.BooksRecordService.API.Application.Commands
{
    public class DeleteBookCommand : IRequest<string>
    {
        public int BookId { get; init; } 
    }
}
