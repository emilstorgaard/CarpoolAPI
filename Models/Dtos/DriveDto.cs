namespace CarpoolAPI.Models.Dtos
{
    public class DriveDto
    {
        public Guid DriverId { get; set; }
        public int Distance { get; set; }
        public DateTime Date { get; set; }
    }
}
