using BooksCqrsApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace BooksCqrsApi.Infrastructure.Persistence;

public class SqliteBookRepository : IBookRepository
{
    private readonly BookDbContext _context;

    public SqliteBookRepository(BookDbContext context)
    {
        _context = context;
    }

    public async Task<Book> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.Books.FindAsync(new object[] { id }, cancellationToken);
    }

    public IQueryable<Book> GetAllQueryable()
    {
        return _context.Books.AsQueryable();
    }

    public IQueryable<Book> GetAll()
    {
        return _context.Books.AsQueryable();
    }

    public async Task<int> AddAsync(Book book, CancellationToken cancellationToken)
    {
        _context.Books.Add(book);
        await _context.SaveChangesAsync(cancellationToken);
        return book.Id;
    }

    public async Task<bool> UpdateAsync(Book book, CancellationToken cancellationToken)
    {
        _context.Books.Update(book);
        return await _context.SaveChangesAsync(cancellationToken) > 0;
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var book = await GetByIdAsync(id, cancellationToken);
        if (book == null) return false;
        
        _context.Books.Remove(book);
        return await _context.SaveChangesAsync(cancellationToken) > 0;
    }
}