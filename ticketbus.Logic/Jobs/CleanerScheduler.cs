using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;

namespace ticketbus.Logic.Jobs
{
    public class CleanerScheduler
    {
        public static async void Start()
        {
            IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();
            await scheduler.Start();

            IJobDetail job = JobBuilder.Create<ChosenTicketsCleaner>().Build();

            ITrigger trigger = TriggerBuilder.Create()  
                .WithIdentity("cleaner", "group1")     
                .StartNow()                            
                .WithSimpleSchedule(x => x            
                    .WithIntervalInMinutes(1)         
                    .RepeatForever())                   
                .Build();                              

            await scheduler.ScheduleJob(job, trigger);        // начинаем выполнение работы
        }
    }
}
