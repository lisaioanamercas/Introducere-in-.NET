using BooksCqrsApi.Domain;

namespace BooksCqrsApi.Infrastructure.Persistence;

public class InMemoryBookRepository : IBookRepository
{
    private readonly List<Book> _books = new();
    private int _nextId = 1;
    
    public Task<Book> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return Task.FromResult(_books.FirstOrDefault(b => b.Id == id));
    }
    
    public IQueryable<Book> GetAllQueryable()
    {
        return _books.AsQueryable();
    }
    
    public Task<int> AddAsync(Book book, CancellationToken cancellationToken)
    {
        book.Id = _nextId++;
        _books.Add(book);
        return Task.FromResult(book.Id);
    }
    
    public Task<bool> UpdateAsync(Book book, CancellationToken cancellationToken)
    {
        var existing = _books.FirstOrDefault(b => b.Id == book.Id);
        if (existing == null) return Task.FromResult(false);
        
        var index = _books.IndexOf(existing);
        _books[index] = book;
        return Task.FromResult(true);
    }
    
    public Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var book = _books.FirstOrDefault(b => b.Id == id);
        if (book == null) return Task.FromResult(false);
        
        _books.Remove(book);
        return Task.FromResult(true);
    }
    
    public IQueryable<Book> GetAll()
    {
        return _books.AsQueryable();
    }
    
}