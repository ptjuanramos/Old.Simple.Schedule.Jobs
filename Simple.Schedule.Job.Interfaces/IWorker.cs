using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Schedule.Job.Interfaces
{
    public interface IWorker
    {
        Task Work();
    }
}
