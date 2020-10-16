using System;
using System.Collections.Generic;
using System.Text;

namespace Simple.Schedule.Job
{
    internal static class CronExpression
    {
        public const string Daily = "0 0 * * *"; 
        public const string Hourly = "0 * * * *"; 
        public const string Weekly = "0 0 * * 0"; 
        public const string Monthly = "0 0 1 * *"; 
    }
}
