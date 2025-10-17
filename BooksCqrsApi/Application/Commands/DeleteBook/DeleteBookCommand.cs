using MediatR;

namespace BooksCqrsApi.Application.Commands.DeleteBook;

public record DeleteBookCommand(int Id) : IRequest<bool>;
