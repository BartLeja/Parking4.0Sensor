using System;

namespace Parking4._0Sensor
{
    public class ParkingSpotDto
    {
        public Guid Id { get; set; }
        public bool Status { get; set; }
        public DateTime Date { get; set; }
        //public string Position { get; set; }
    }
}
