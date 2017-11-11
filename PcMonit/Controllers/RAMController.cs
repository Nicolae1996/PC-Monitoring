using PcMonit.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PcMonit.Controllers
{
    public class RAMController : ApiController
    {
        [HttpGet]
        [Route("api/ram/GetTotalRam")]
        public string GetTotalRam()
        {
            var ram = MemoryHelper.GetGlobalMemoryStatusEX() / 1024 / 1024;
            return ram.ToString("n2") + "MB";
        }
        [HttpGet]
        [Route("api/ram/GetAvailabileRam")]
        public string GetAvailabileRam()
        {
            PerformanceCounter ramCounter;
            ramCounter = new PerformanceCounter("Memory", "Available MBytes");
            return ramCounter.NextValue().ToString() + "MB";
        }
        [HttpGet]
        [Route("api/ram/GetUsedRam")]
        public string GetUsedRam()
        {
            string value = "";
            try
            {
                PerformanceCounter ramCounter;
                ramCounter = new PerformanceCounter("Memory", "Available MBytes");
                float ram = (float)MemoryHelper.GetGlobalMemoryStatusEX() / 1024 / 1024;
                float usedram = ramCounter.NextValue();
                value = (ram - usedram).ToString("n2") + "MB";
            }
            catch (Exception ex)
            {
                value = ex.ToString();
            }
            return value;
        }
    }
}
