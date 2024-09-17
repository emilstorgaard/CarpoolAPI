namespace CarpoolAPI.Models.Dtos
{
    public class DriverStatsDto
    {
        public Guid DriverId { get; set; }
        public string DriverName { get; set; }
        public int TotalDrives { get; set; }
        public int TotalDistance { get; set; }
    }
}
