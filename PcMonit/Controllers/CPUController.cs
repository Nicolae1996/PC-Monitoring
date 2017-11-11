using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace PcMonit.Controllers
{
    [RoutePrefix("api/{controller}/{action}")]
    public class CPUController : ApiController
    {
        public CPUController()
        {

        }
        // GET: api/CPU/5
        public string Get()
        {
            PerformanceCounter cpuCounter;
            cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            float MCpu = 0;
            int index = 0;
            for (int i = 0; i < 5; i++)
            {
                MCpu += cpuCounter.NextValue();
                Thread.Sleep(20);
                index++;
            }
            return  (MCpu/--index).ToString("n2") + "%";
        }
    }
}
