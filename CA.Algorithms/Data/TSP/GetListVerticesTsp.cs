using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CA.Algorithms.Data.TSP
{
    public class GetListVerticesTsp : IGetListVerticesTsp
    {
        public List<VertexTsp> GetList()
        {
            using (TextReader reader = File.OpenText(@"..\..\..\CA.Algorithms\Data\tsp\tsp.txt"))
            {
                var list = new List<VertexTsp>();
                string text = reader.ReadLine();
                int count = int.Parse(text);

                int vertexId = 0;
                text = reader.ReadLine();
                while (text != null)
                {
                    string[] splited = text.Split(' ');
                    
                    list.Add(new VertexTsp
                        {
                            Id = vertexId,
                            X = float.Parse(splited[0]),
                            Y = float.Parse(splited[1])
                        });
                    text = reader.ReadLine();
                    vertexId++;
                }

                return list;
            }
        }
    }
}
