namespace CarpoolAPI.Models.Dtos
{
    public class TripDto
    {
        public Guid UserId { get; set; }
        public int Distance { get; set; }
        public bool IsCarpool { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime StopDate { get; set; }
    }
}
