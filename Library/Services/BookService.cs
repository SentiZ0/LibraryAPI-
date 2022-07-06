using Library.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Library.Models;
using Library.Services.Models;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryDbContext _context;

        public BookService(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<long> AddBookAsync(BookDto book)
        {
            var newBook = new Book()
            {
                Title = book.Title,
                Author = book.Author,
                Description = book.Description,
                Price = book.Price               
            };

            _context.Books.Add(newBook);
            await _context.SaveChangesAsync();

            return newBook.Id;
        }

        public Task<List<BookDto>> GetAllBooksAsync()
        {
            return _context.Books.Select(x => new BookDto
            {
                Id = x.Id,
                Title = x.Title,
                Author = x.Author,
                Description = x.Description,
                Price = x.Price
            }).ToListAsync();
        }

        public Task<BookDto> GetSingleBookAsync(long id)
        {
            var book = _context.Books.Select(x => new BookDto
            {
                Id = x.Id,
                Title = x.Title,
                Author = x.Author,
                Description = x.Description,
                Price = x.Price
            }).FirstOrDefaultAsync(x => x.Id == id);

            return book;
        }

        public Task ModifyBookAsync(BookDto book)
        {
            var modifiedBook = new Book()
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Description = book.Description,
                Price = book.Price
            };

            _context.Entry(modifiedBook).State = EntityState.Modified;
            _context.SaveChangesAsync();

            return Task.CompletedTask;
        }

        public Task DeleteBookAsync(BookDto book)
        {
            var bookToRemove = new Book()
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Description = book.Description,
                Price = book.Price
            };

            _context.Books.Remove(bookToRemove);
            _context.SaveChangesAsync();

            return Task.CompletedTask;
        }
    }
}
