using Library.Models;
using Library.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Services.Interfaces
{
    public interface IBookService
    {
        public Task<long> AddBookAsync(BookDto book);
        public Task<List<BookDto>> GetAllBooksAsync();      
        public Task<BookDto> GetSingleBookAsync(long id);
        public Task ModifyBookAsync(BookDto book);
        public Task DeleteBookAsync(BookDto book);
    }
}
