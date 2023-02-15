namespace Elabor8.Bradl.Entities
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? FirstName { get; set; } = Util.GenerateName(8);
        public string? LastName { get; set; } = Util.GenerateName(5);
    }
}
