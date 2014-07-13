namespace CA.Algorithms.Data.SchedulingProblem
{
    public class Job
    {
        public Job(int weight, int length)
        {
            Weight = weight;
            Length = length;
        }

        public int Weight { get; set; }
        public int Length { get; set; }
    }
}