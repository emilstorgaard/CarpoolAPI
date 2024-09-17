using System.Text.Json.Serialization;

namespace CarpoolAPI.Models.Entities
{
    public class Drive
    {
        public Guid Id { get; set; }
        public Guid DriverId { get; set; }
        public int Distance { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [JsonIgnore]
        public Driver Driver { get; set; }
    }
}

