using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CA.Algorithms.Data.SchedulingProblem
{
    public interface IJobsDataManager
    {
        Job[] GetJobs();
    }
}
