using BooksCqrsApi.Domain;
using BooksCqrsApi.Infrastructure.Persistence;
using MediatR;

namespace BooksCqrsApi.Application.Queries.GetBookById;

public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, Book>
{
    private readonly IBookRepository _repository;
    
    public async Task<Book> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetByIdAsync(request.Id, cancellationToken);
    }
}