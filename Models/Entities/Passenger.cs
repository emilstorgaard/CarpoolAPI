using System.Text.Json.Serialization;

namespace CarpoolAPI.Models.Entities
{
    public class Passenger
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid TripId { get; set; }
    }
}
