namespace TechLibrary.API.Domain.Entities
{
    public class Book
    {
        public Guid ID { get; set; } = Guid.NewGuid();
        public string Title { get; set; }  = string.Empty;
        public string Author { get; set; } = string.Empty ;
        public int Amount { get; set; }
    }
}
