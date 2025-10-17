using BooksCqrsApi.Infrastructure.Persistence;
using MediatR;

namespace BooksCqrsApi.Application.Commands.DeleteBook;

public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, bool>
{
    private readonly IBookRepository _repository;
    
    public async Task<bool> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        return await _repository.DeleteAsync(request.Id, cancellationToken);
    }
}