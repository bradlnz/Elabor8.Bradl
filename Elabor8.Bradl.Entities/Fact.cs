namespace Elabor8.Bradl.Entities
{
    public class Fact
    {
        public Guid Id { get; set; }
        public string? Text { get; set; }
        public string? Type { get; set; }
        public User User => new();
        public Status Status => new();
        public bool Used { get; set; }
        public string? Source { get; set; } = "user";
        public bool Deleted { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Upvotes => new Random().Next(1, 20);
    }
}
