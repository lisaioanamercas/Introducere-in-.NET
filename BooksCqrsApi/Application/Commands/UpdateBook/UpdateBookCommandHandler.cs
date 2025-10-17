using BooksCqrsApi.Infrastructure.Persistence;
using MediatR;

namespace BooksCqrsApi.Application.Commands.UpdateBook;

public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, bool>
{
    private readonly IBookRepository _repository;
    
    public async Task<bool> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var book = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (book == null) return false;
        
        book.Title = request.Title;
        book.Author = request.Author;
        book.Year = request.Year;
        
        return await _repository.UpdateAsync(book, cancellationToken);
    }
}