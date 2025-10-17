using MediatR;

namespace BooksCqrsApi.Application.Commands.UpdateBook;

// Application/Commands/UpdateBook/UpdateBookCommand.cs
public record UpdateBookCommand(int Id, string Title, string Author, int Year) 
    : IRequest<bool>;

