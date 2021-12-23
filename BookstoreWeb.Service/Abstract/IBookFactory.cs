using BookstoreWeb.Entities.Dtos;
using BookstoreWeb.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreWeb.Services.Abstract
{
    public interface IBookFactory
    {

        Task<IDataResult<BookDto>> GetAsync(int bookId);
        Task<IDataResult<BookListDto>> GetAllAsync();
        Task<IResult> AddAsync(AddBookDto addBookDto, string createdByName);
        Task<IResult> UpdateAsync(UpdateBookDto updateBookDto, string modifiedByName);
        Task<IResult> DeleteAsync(int bookId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int bookId);
        Task<IDataResult<int>> CountAsync();
        Task<IDataResult<int>> CountByNonDeletedAsync();
    }
}
