namespace CarpoolAPI.Models.Entities
{
    public class Driver
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
