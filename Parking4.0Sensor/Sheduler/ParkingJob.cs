using Quartz;
using System;
using System.Threading.Tasks;

namespace Parking4._0Sensor
{
    public class ParkingJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            var parkingSpotDto = new ParkingSpotDto
            {
                Date = DateTime.Now,
                Status = ParkingStateService.GetInstance().ToogleParkingSpotStatus(),
                Id = ParkingStateService.GetInstance().GetId()

            };
            await ParkingHttpClient.SendParkingSpaceStatus(parkingSpotDto);
        }
    }
}
