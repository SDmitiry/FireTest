using FireTest.Models;
using Quartz;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FireTest.Jobs
{
    public class UpdateUsers: IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            //Обновляем пользовательскую группу когда он сменил курс
        }
    }
}