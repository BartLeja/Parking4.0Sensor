using System;

namespace Parking4._0Sensor
{
    public class ParkingStateService
    {
        public string LocalMachineUrl { get; set; } = "https://localhost:5001/parking/api";
        private ParkingStateService() {
            _id = Guid.NewGuid();
        }
        private static ParkingStateService _instance;
        private Guid _id;
        private bool _parkingSpotStatus = false;
       
        public static ParkingStateService GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ParkingStateService();
            }
            return _instance;
        }

        public Guid GetId() => _id;

        public bool ToogleParkingSpotStatus()
        {
            _parkingSpotStatus = !_parkingSpotStatus;
            return _parkingSpotStatus;
        }

        public bool GetParkingSpotStatus() => _parkingSpotStatus;
    }
}
