using CA.Algorithms.Data.SchedulingProblem;

namespace CA.Algorithms.Implementations.SchedulingProblem
{
    public class SchedulingDivision : SchedulingBase
    {
        public override double GetJobWeight(Job job)
        {
            return (double)job.Weight/job.Length;
        }
    }
}
