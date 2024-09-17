namespace CarpoolAPI.Models.Entities
{
    public class Drive
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public int Distance { get; set; }
        public DateOnly Date { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
