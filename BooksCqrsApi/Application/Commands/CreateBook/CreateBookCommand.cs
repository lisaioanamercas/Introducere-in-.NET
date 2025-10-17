using BooksCqrsApi.Domain;
using FluentValidation;
using MediatR;

namespace BooksCqrsApi.Application.Commands.CreateBook;

// Application/Commands/CreateBook/CreateBookCommand.cs
public record CreateBookCommand(string Title, string Author, int Year) 
    : IRequest<int>;
    