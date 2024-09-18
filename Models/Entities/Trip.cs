using System.Text.Json.Serialization;

namespace CarpoolAPI.Models.Entities
{
    public class Trip
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public int Distance { get; set; }
        public bool IsCarpool { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime StopDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [JsonIgnore]
        public User User { get; set; }
    }
}

