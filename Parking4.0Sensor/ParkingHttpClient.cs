using System.Net.Http;
using System.Threading.Tasks;
using System;

namespace Parking4._0Sensor
{
    public static class ParkingHttpClient
    {
        private static string parking40LocalMachine = ParkingStateService.GetInstance().LocalMachineUrl;

        public static async Task SendParkingSpaceStatus(ParkingSpotDto parkingSpotDto)
        {
            using (var client = new HttpClient())
            {
                try
                {
                   await client.PostAsJsonAsync<ParkingSpotDto>(parking40LocalMachine, parkingSpotDto);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}
