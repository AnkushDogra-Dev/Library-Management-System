using LMS.BooksRecordService.API.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.BooksRecordService.API.Application.Queries
{
    public class GetAllBookQuery : IRequest<List<BookDTO>> 
    {
    }
}