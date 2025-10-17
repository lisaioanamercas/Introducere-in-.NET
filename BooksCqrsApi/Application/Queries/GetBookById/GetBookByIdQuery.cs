using BooksCqrsApi.Domain;
using MediatR;

namespace BooksCqrsApi.Application.Queries.GetBookById;

public record GetBookByIdQuery(int Id) : IRequest<Book>;
