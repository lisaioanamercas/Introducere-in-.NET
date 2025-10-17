using BooksCqrsApi.Application.Commands.CreateBook;
using BooksCqrsApi.Application.Commands.DeleteBook;
using BooksCqrsApi.Application.Commands.UpdateBook;
using BooksCqrsApi.Application.Queries.GetAllBooks;
using BooksCqrsApi.Application.Queries.GetBookById;
using BooksCqrsApi.API.Dtos;
using BooksCqrsApi.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using BooksCqrsApi.Api.Dtos;

namespace BooksCqrsApi.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public BooksController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<ActionResult<PagedResult<Book>>> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 10, CancellationToken cancellationToken = default)
    {
        var result = await _mediator.Send(new GetAllBooksQuery(page, pageSize), cancellationToken);
        return Ok(result);
    }
    
    [HttpGet("{id}", Name = "GetBookById")]
    public async Task<ActionResult<Book>> GetById(int id, CancellationToken cancellationToken = default)
    {
        var book = await _mediator.Send(new GetBookByIdQuery(id), cancellationToken);
        if (book == null) return NotFound();
        return Ok(book);
    }
    
    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] CreateBookDto dto, CancellationToken cancellationToken = default)
    {
        var command = new CreateBookCommand(dto.Title, dto.Author, dto.Year);
        var id = await _mediator.Send(command, cancellationToken);
        return CreatedAtRoute("GetBookById", new { id }, id);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, [FromBody] UpdateBookCommand command, CancellationToken cancellationToken = default)
    {
        if (id != command.Id) return BadRequest();
        
        var success = await _mediator.Send(command, cancellationToken);
        if (!success) return NotFound();
        
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id, CancellationToken cancellationToken = default)
    {
        var success = await _mediator.Send(new DeleteBookCommand(id), cancellationToken);
        if (!success) return NotFound();
        
        return NoContent();
    }
}
