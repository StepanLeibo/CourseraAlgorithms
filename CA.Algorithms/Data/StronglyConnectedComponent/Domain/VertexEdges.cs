using System.Collections.Generic;

namespace CA.Algorithms.Data.StronglyConnectedComponent.Domain
{
    public class VertexEdgesScc
    {
        public VertexEdgesScc()
        {
            Edges = new List<int>();
        }

        public VertexEdgesScc(int i)
        {
            ID = i;
            Edges = new List<int>();
        }

        public static implicit operator VertexEdgesScc(int i)
        {
            return new VertexEdgesScc
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
