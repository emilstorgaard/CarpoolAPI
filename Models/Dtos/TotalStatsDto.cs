﻿namespace CarpoolAPI.Models.Dtos
{
    public class TotalStatsDto
    {
        public int TotalTrips { get; set; }
        public int TotalDistance { get; set; }
        public int TotalUsers { get; set; }
        public TimeSpan TotalTime { get; set; }
    }
}
