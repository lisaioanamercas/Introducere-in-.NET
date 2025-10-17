using BooksCqrsApi.Domain;

namespace BooksCqrsApi.Infrastructure.Persistence;
public interface IBookRepository
{
    Task<Book> GetByIdAsync(int id, CancellationToken cancellationToken);
    IQueryable<Book> GetAllQueryable();
    Task<int> AddAsync(Book book, CancellationToken cancellationToken);
    Task<bool> UpdateAsync(Book book, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
    IQueryable<Book> GetAll();
}
