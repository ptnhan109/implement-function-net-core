using Microsoft.Playwright;
using System;
using System.Threading.Tasks;

namespace AutoSurvey
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            //await RollUpProcessor.RollUp(Enums.EnumCheckOutTypes.MorningCheckIn);
            await VDIProcessor.VdiLogin();
        }
    }
}
