using BooksCqrsApi.Domain;
using BooksCqrsApi.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BooksCqrsApi.Application.Queries.GetAllBooks;

public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, PagedResult<Book>>
{
    private readonly IBookRepository _repository;
    
    public GetAllBooksQueryHandler(IBookRepository repository)
    {
        _repository = repository;
    }
    
    // public async Task<PagedResult<Book>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    // {
    //     // IMPORTANT: Apply pagination BEFORE materializing (before ToList)
    //     var query = _repository.GetAllQueryable();
    //     var totalCount = await query.CountAsync(cancellationToken);
    //     
    //     var items = await query
    //         .Skip((request.Page - 1) * request.PageSize)
    //         .Take(request.PageSize)
    //         .ToListAsync(cancellationToken);
    //     
    //     return new PagedResult<Book>
    //     {
    //         Items = items,
    //         TotalCount = totalCount,
    //         Page = request.Page,
    //         PageSize = request.PageSize
    //     };
    // }
    
public async Task<PagedResult<Book>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {
        var query = _repository.GetAll();
        
        // Use synchronous Count() instead of CountAsync()
        var totalCount = query.Count();
        
        var books = query
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToList();
        
        return new PagedResult<Book>
        {
            Items = books,
            TotalCount = totalCount,
            Page = request.Page,
            PageSize = request.PageSize
        };
    }
    
}