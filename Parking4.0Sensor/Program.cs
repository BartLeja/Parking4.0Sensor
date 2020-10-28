using Quartz.Logging;
using System;
using System.Threading.Tasks;

namespace Parking4._0Sensor
{
    class Program
    {
        static async Task Main(string[] args)
        {
            LogProvider.SetCurrentLogProvider(new ConsoleLogProvider());
            Console.WriteLine("Set url address of local machine");
            var url = Console.ReadLine();
            if (url != "") ParkingStateService.GetInstance().LocalMachineUrl = url;
            var scheduler = new QuartzSchedulerService();
            await scheduler.QuartzSchedulerStart();
            await scheduler.ScheduleParkingJob();

            while (true)
            {
                Console.WriteLine("Press 1 for test status toogle of parking spot");
                if (Console.ReadLine() == "1")
                    await ParkingHttpClient.SendParkingSpaceStatus(new ParkingSpotDto
                    {
                        Date = DateTime.Now,
                        Status = ParkingStateService.GetInstance().ToogleParkingSpotStatus(),
                        Id = ParkingStateService.GetInstance().GetId()

                    });

            }
        }
    }
}
