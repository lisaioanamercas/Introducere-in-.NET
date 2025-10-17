using BooksCqrsApi.Domain;
using BooksCqrsApi.Infrastructure.Persistence;
using MediatR;

namespace BooksCqrsApi.Application.Commands.CreateBook;

public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
{
    private readonly IBookRepository _repository;
    
    public CreateBookCommandHandler(IBookRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var book = new Book
        {
            Title = request.Title,
            Author = request.Author,
            Year = request.Year
        };
        
        return await _repository.AddAsync(book, cancellationToken);
    }
}