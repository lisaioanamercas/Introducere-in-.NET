namespace BooksCqrsApi.Api.Dtos
{
    public class CreateBookDto
    {
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public int Year { get; set; }
    }
}
