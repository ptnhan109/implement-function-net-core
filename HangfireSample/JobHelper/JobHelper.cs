using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HangfireSample.JobHelper
{
    public class JobHelper
    {
        public void Job(string input)
        {
            string output = $"{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")} {input}";
            System.Diagnostics.Debug.Write(output);
        }
        public void Enqueue()
        {
            BackgroundJob.Enqueue(() => Job("Enqueue"));
        }
        public void Schedule()
        {
            BackgroundJob.Schedule(() => Job("Schedule"), DateTime.Now.AddSeconds(10) - DateTime.Now);
        }
    }
}
