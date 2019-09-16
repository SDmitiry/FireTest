using Quartz;
using Quartz.Impl;

namespace FireTest.Jobs
{
    public class UpdateSheduler
    {
        public static async void Start()
        {
            IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();
            await scheduler.Start();

            IJobDetail job = JobBuilder.Create<UpdateUsers>().Build();

            ITrigger trigger = TriggerBuilder.Create() 
                .WithIdentity("trigger", "group") 
                .StartNow()                  
                .WithSimpleSchedule(x => x       
                    .WithIntervalInHours(24)
   
                    .RepeatForever())              
                .Build();                           

            await scheduler.ScheduleJob(job, trigger);      
        }
    }
}