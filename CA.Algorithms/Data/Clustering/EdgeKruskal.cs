namespace CA.Algorithms.Data.Clustering
{
    public class EdgeKruskal
    {
        public EdgeKruskal(int start, int end, int weight)
        {
            Start = start;
            End = end;
            Weight = weight;
        }

        public int Start { get; set; }
        public int End { get; set; }
        public int Weight { get; set; }
    }
}
