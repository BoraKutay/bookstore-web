using AutoMapper;
using bookstore.Models;
using BookstoreWeb.Data.Abstract;
using BookstoreWeb.Entities.Dtos;
using BookstoreWeb.Services.Abstract;
using BookstoreWeb.Shared.Utilities.Results.Abstract;
using BookstoreWeb.Shared.Utilities.Results.ComplexTypes;
using BookstoreWeb.Shared.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreWeb.Services.Concrete
{
    public class BookFactory : IBookFactory
    {

        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public BookFactory(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IResult> AddAsync(AddBookDto addBookDto, string createdByName)
        {
            var book = this.mapper.Map<Book>(addBookDto);
            book.CreatedByName = createdByName;
            book.ModifiedByName = createdByName;
            book.Id = 1;
            await this.unitOfWork.Books.AddASync(book);
            await this.unitOfWork.SaveAsync();
            return new Result(ResultStatus.Success);
        }

        public async Task<IDataResult<int>> CountAsync()
        {
            var countBook = await this.unitOfWork.Books.CountAsync();
            
            if(countBook >= 0)
            {
                return new DataResult<int>(ResultStatus.Success, countBook);
            }
            return new DataResult<int>(ResultStatus.Error, countBook);

        }

        public async Task<IDataResult<int>> CountByNonDeletedAsync()
        {
            var countBook = await this.unitOfWork.Books.CountAsync(b => !b.IsDeleted);

            if (countBook >= 0)
            {
                return new DataResult<int>(ResultStatus.Success, countBook);
            }
            return new DataResult<int>(ResultStatus.Error, countBook);

        }

        public async Task<IResult> DeleteAsync(int bookId, string modifiedByName)
        {
            var book = await this.unitOfWork.Books.GetAsync(b => b.Id == bookId);
            book.IsDeleted = true;
            book.ModifiedByName = modifiedByName;
            book.ModifiedDate = DateTime.Now;

            await this.unitOfWork.Books.UpdateAsync(book);
            await this.unitOfWork.SaveAsync();

            return new Result(ResultStatus.Success);
        }

        public async Task<IDataResult<BookListDto>> GetAllAsync()
        {
            var books = await this.unitOfWork.Books.GetAllAsync(null, b => b.Id);

            if(books.Count >= 0)
            {
                return new DataResult<BookListDto>(ResultStatus.Success, new BookListDto { Books = books, ResultStatus = ResultStatus.Success });
            }
            return new DataResult<BookListDto>(ResultStatus.Error, null);
        }

        public async Task<IDataResult<BookDto>> GetAsync(int bookId)
        {
            var book = await this.unitOfWork.Books.GetAsync(b => b.Id == bookId);

            if(book != null)
            {
                return new DataResult<BookDto>(ResultStatus.Success, new BookDto { Book = book, ResultStatus = ResultStatus.Success });
            }
            return new DataResult<BookDto>(ResultStatus.Error, null);
        }

        public async Task<IResult> HardDeleteAsync(int bookId)
        {
            var res = await this.unitOfWork.Books.AnyAsync(b => b.Id == bookId);
            if (res)
            {
                var book = await this.unitOfWork.Books.GetAsync(b => b.Id == bookId);
                await this.unitOfWork.Books.DeleteAsync(book);
                await this.unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success);
            }
            return new Result(ResultStatus.Error);
        }

        public async Task<IResult> UpdateAsync(UpdateBookDto updateBookDto, string modifiedByName)
        {
            var book = this.mapper.Map<Book>(updateBookDto);
            book.ModifiedByName = modifiedByName;
            await this.unitOfWork.Books.UpdateAsync(book);
            await this.unitOfWork.SaveAsync();
            return new Result(ResultStatus.Success);
        }
    }
}
