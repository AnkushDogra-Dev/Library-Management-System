using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.BooksRecordService.API.Application.Commands
{
    public class DeleteBookCommand
    {
       public string BookId { get; init; }
       public int AvailableCopies { get; init; }
    }
}