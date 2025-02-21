namespace TechLibrary.Api.Domain.Entities
{
    public class User
    {

        public Guid ID { get; set; } = Guid.NewGuid();
            public string? Nome { get; set; }
            public string? Email { get; set; }
            public string? Password { get; set; }
        
    }
}


