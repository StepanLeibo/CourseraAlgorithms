using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CA.Algorithms.Data.TSP
{
    public class VertexTsp
    {
        public int Id { get; set; }

        public float X { get; set; }
        
        public float Y { get; set; }

        public float DestinationToVertex(VertexTsp other)
        {
            return (float)Math.Sqrt(Math.Pow((this.X - other.X), 2) + Math.Pow((this.Y - other.Y), 2));
        }
    }
}
