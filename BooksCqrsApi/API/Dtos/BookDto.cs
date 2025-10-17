namespace BooksCqrsApi.API.Dtos;

public class BookDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Author { get; set; } = null!;
    public int Year { get; set; }
}