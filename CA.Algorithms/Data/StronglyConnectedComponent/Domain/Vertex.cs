using System;

namespace CA.Algorithms.Data.StronglyConnectedComponent.Domain
{
    public class VertexScc : ICloneable
    {
        public VertexScc()
        {
            
        }
        
        public VertexScc(int i)
        {
            ID = i;
        }

        public static implicit operator VertexScc(int i)
        {
            return new VertexScc
                {
                    ID = i
                };
        }

        public int ID { get; set; }
        public bool Found { get; set; }
        public object Clone()
        {
            return new VertexScc
                {
                    ID = ID,
                    Found = Found
                };
        }
    }
}
