using BooksCqrsApi.Application.Commands.CreateBook;
using BooksCqrsApi.Application.Commands.DeleteBook;
using BooksCqrsApi.Application.Commands.UpdateBook;
using BooksCqrsApi.Application.Queries.GetAllBooks;
using BooksCqrsApi.Application.Queries.GetBookById;
using BooksCqrsApi.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
    public async Task<ActionResult<PagedResult<Book>>> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var result = await _mediator.Send(new GetAllBooksQuery(page, pageSize));
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Book>> GetById(int id)
    {
        var book = await _mediator.Send(new GetBookByIdQuery(id));
        if (book == null) return NotFound();
        return Ok(book);
    }
    
    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateBookCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, id);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, UpdateBookCommand command)
    {
        if (id != command.Id) return BadRequest();
        
        var success = await _mediator.Send(command);
        if (!success) return NotFound();
        
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var success = await _mediator.Send(new DeleteBookCommand(id));
        if (!success) return NotFound();
        
        return NoContent();
    }
}