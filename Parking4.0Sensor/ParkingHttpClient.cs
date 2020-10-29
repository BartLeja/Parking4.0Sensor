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
            //Fix for problems with SSL
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
           
            using (var client = new HttpClient(clientHandler))
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
