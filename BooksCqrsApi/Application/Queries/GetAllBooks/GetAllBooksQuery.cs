using BooksCqrsApi.Domain;
using MediatR;

namespace BooksCqrsApi.Application.Queries.GetAllBooks;

// Application/Queries/GetAllBooks/GetAllBooksQuery.cs
public record GetAllBooksQuery(int Page = 1, int PageSize = 10) 
    : IRequest<PagedResult<Book>>;
public class PagedResult<T>
{
    public IEnumerable<T> Items { get; set; }
    public int TotalCount { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
}