namespace Assignment.Models
{
    public class AddBookViewModel
    {
        public string Title { get; set; }

        public string? Publisher { get; set; }

        public DateOnly? PublishedDate { get; set; }

        public string? ISBN { get; set; }

        public float? Price { get; set; }

        public Guid AuthorId { get; set; }

        public string? Genre { get; set; }
    }
}
