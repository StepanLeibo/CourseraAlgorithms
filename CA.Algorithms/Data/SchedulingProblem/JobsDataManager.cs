using System;
using System.Collections.Generic;
using System.IO;
using CA.Algorithms.Data.KargerMinCut.Domain;

namespace CA.Algorithms.Data.SchedulingProblem
{
    public class JobsDataManager : IJobsDataManager
    {
        public Job[] GetJobs()
        {
            using (TextReader reader = File.OpenText(@"..\..\..\CA.Algorithms\Data\SchedulingProblem\Jobs.txt"))
            {
                var text = reader.ReadLine();
                int arrayLength;
                if (!Int32.TryParse(text, out arrayLength))
                {
                    throw new ArgumentException("Array length wasn't provided.");
                }
                var jobs = new Job[arrayLength];
                int counter = 0;
                while (text != null)
                {
                    string[] splited = text.Split(' ');

                    if (splited.Length == 2)
                    {
                        int weight;
                        if (int.TryParse(splited[0], out weight))
                        {
                            int length;
                            if (int.TryParse(splited[1], out length))
                            {
                                jobs[counter] = new Job(weight, length);
                                counter++;
                            }
                        }
                    }

                    text = reader.ReadLine();
                }

                return jobs;
            }
        }
    }
}
