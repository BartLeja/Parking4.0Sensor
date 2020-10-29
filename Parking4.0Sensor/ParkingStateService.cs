using System;

namespace Parking4._0Sensor
{
    public class ParkingStateService
    {
        public string LocalMachineUrl { get; set; } = "http://192.168.1.108:5000/api/parking";
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
