namespace Library.Services.Models
{
    public class BookDto
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public decimal PriceUsd => Price / 2;
    }
}
