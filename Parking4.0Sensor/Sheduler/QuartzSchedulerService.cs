using Quartz.Impl;
using Quartz;
using System.Threading.Tasks;
using System;

namespace Parking4._0Sensor
{
    public class QuartzSchedulerService
    {
        private StdSchedulerFactory _factory { get; set; }
        private IScheduler _scheduler; 
        public QuartzSchedulerService()
        {
            _factory =  new StdSchedulerFactory();
        }

        public async Task QuartzSchedulerStart()
        {
            _scheduler = await _factory.GetScheduler();
            await _scheduler.Start();
        }

        public async Task ScheduleParkingJob()
        {
            // define the job and tie it to our HelloJob class
            IJobDetail job = JobBuilder.Create<ParkingJob>()
                .WithIdentity("job1", "group1")
                .Build();

            // Trigger the job to run now, and then repeat every 10 seconds
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("trigger1", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInMinutes(new Random().Next(1, 18))
                    .RepeatForever())
                .Build();

            // Tell quartz to schedule the job using our trigger
            await _scheduler.ScheduleJob(job, trigger);
        }

        public async Task QuartzSchedulerStop()
        {
            _scheduler = await _factory.GetScheduler();
            await _scheduler.Shutdown();
        }

    }
}
