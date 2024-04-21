namespace Assignment.Models
{
    public class Books
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string? Publisher { get; set; }
        public DateOnly? PublishedDate { get; set; }
        public string? ISBN { get; set; }
        public float? Price { get; set; }
        
        public Authors Authors { get; set; }

        public string? Genre { get; set; }
    }
}
