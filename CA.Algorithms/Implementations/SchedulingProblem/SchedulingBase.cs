using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CA.Algorithms.Data.SchedulingProblem;

namespace CA.Algorithms.Implementations.SchedulingProblem
{
    public abstract class SchedulingBase
    {
        public long Execute(Job[] jobs)
        {
            long waitAllJobsLength = 0;

            jobs = jobs.OrderByDescending(GetJobWeight).ToArray();
            var jobsLength = jobs.Length;

            for (var i = 0; i < jobsLength; i++)
            {
                var jobLength = jobs[i].Length;
                int weightSum = 0;
                for (var j = i; j < jobsLength; j ++)
                {
                    weightSum += jobs[j].Weight;
                }

                waitAllJobsLength += weightSum*jobLength;
            }

            return waitAllJobsLength;
        }

        /// <summary>
        /// Execute jobs with maximum weight first
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        public abstract double GetJobWeight(Job job);
    }
}
