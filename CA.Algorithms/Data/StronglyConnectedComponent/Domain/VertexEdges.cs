using System.Collections.Generic;

namespace CA.Algorithms.Data.StronglyConnectedComponent.Domain
{
    public class VertexWithEdgesScc
    {
        public VertexWithEdgesScc()
        {
            Edges = new List<int>();
        }

        public VertexWithEdgesScc(int i)
        {
            ID = i;
            Edges = new List<int>();
        }

        public static implicit operator VertexWithEdgesScc(int i)
        {
            return new VertexWithEdgesScc
                {
                    ID = i,
                    Edges = new List<int>()
                };
        }

        public int ID { get; set; }
        public bool Found { get; set; }
        public List<int> Edges { get; set; }
        public int Index { get; set; }
        public int LowLink { get; set; }
    }
}
