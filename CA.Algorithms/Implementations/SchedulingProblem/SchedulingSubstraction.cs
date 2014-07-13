using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CA.Algorithms.Data.SchedulingProblem;

namespace CA.Algorithms.Implementations.SchedulingProblem
{
    public class SchedulingSubstraction : SchedulingBase
    {
        public override double GetJobWeight(Job job)
        {
            return (double)(job.Weight - job.Length) + (double)job.Weight/1000;
        }
    }
}
