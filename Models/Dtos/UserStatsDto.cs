namespace CarpoolAPI.Models.Dtos
{
    public class UserStatsDto
    {
        public Guid UserId { get; set; }
        public required string UserName { get; set; }
        public int TotalTrips { get; set; }
        public int TotalDistance { get; set; }
        public TimeSpan TotalTime { get; set; }
    }
}
