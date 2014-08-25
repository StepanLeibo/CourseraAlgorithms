using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CA.Algorithms.Data.TSP
{
    public class TspBigDataAlgorithm
    {
        float[,] distances;
        
        public float ShortestPathLength(List<VertexTsp> vertices)
        {
            // calculate distances array
            var vertexCount = vertices.Count;
            distances = new float[vertexCount, vertexCount];

            for (int i = 0; i < vertexCount; i++)
            {
                for (int j = i + 1; j < vertexCount; j++)
                {
                    distances[i, j] = distances[j, i] = vertices[i].DestinationToVertex(vertices[j]);
                }
            }

            var subsetCount = (int) Math.Pow(2, vertexCount - 1);

            var bigArray = new BigArray(subsetCount, vertexCount, sizeof (float));

            //var dynamicResults = new float[subsetCount][];
            //for (int i = 0; i < subsetCount; i++)
            //{
            //    dynamicResults[i] = new float[vertexCount];
            //}
            var matrixInited = new bool[subsetCount];

            for (int i = 0; i < subsetCount; i++)
            {
                bigArray.SetElement(i,0, int.MaxValue);
            }

            bigArray.SetElement(0, 0, 0);
            for (int i = 1; i < vertexCount; i++)
            {
                bigArray.SetElement(0, i, int.MaxValue);
            }
            matrixInited[0] = true;

            var measure = new SpeedMeasure.Measure("TSP");
            measure.StartMeasure();

            for (int subsetNum = 1; subsetNum < subsetCount; subsetNum++)
            {
                if (!matrixInited[subsetNum])
                {
                    if (subsetNum%200 == 0)
                    {
                        Console.WriteLine("Progress {0}%", subsetNum * 100 / subsetCount);
                        measure.StopMeasureDisplay();
                    }
                    CalculateSubset(subsetNum, vertices, bigArray, matrixInited, vertexCount);
                }
            }

            float distance = int.MaxValue;

            for (int j = 1; j < vertexCount; j++)
            {
                float tempDistance = bigArray.GetElement(subsetCount - 1, j) + distances[0, j];

                if (tempDistance < distance)
                {
                    distance = tempDistance;
                }
            }

            Console.WriteLine(distance);
            return 0;
        }

        private void CalculateSubset(int subsetNum, List<VertexTsp> vertices, BigArray bigArray, bool[] matrixInited, int vertexCount)
        {
            var fullSubsetDefinition = GetFullSubsetDefinition(subsetNum);
            for (int j = 1; j < vertexCount; j++)
            {
                bigArray.SetElement(subsetNum, j, int.MaxValue);
                var jMask = GetMaskForPosition(j);

                // if j is in current set
                if (IsPosition(jMask, fullSubsetDefinition))
                {
                    var subsetWithoutJFull = AddOrRemovePosition(fullSubsetDefinition, jMask);
                    var subsetWithoutJShort = GetShortSubsetDefinition(subsetWithoutJFull);

                    for (int i = 0; i < vertexCount; i++)
                    {
                        // the same vertex
                        if (i == j)
                        {
                            continue;
                        }

                        // vertex is not in subset
                        if (!IsPosition(subsetWithoutJFull, GetMaskForPosition(i)))
                        {
                            continue;
                        }

                        if (!matrixInited[subsetWithoutJShort])
                        {
                            CalculateSubset(subsetWithoutJShort, vertices, bigArray, matrixInited, vertexCount);
                        }

                        var value = bigArray.GetElement(subsetWithoutJShort, i) + distances[i, j];
                        if (value < bigArray.GetElement(subsetNum, j))
                        {
                            bigArray.SetElement(subsetNum, j, value);
                        }
                    }
                }
            }

            matrixInited[subsetNum] = true;
        }

        private int GetFullSubsetDefinition(int number)
        {
            return (number << 1) + 1;
        }

        private int GetShortSubsetDefinition(int number)
        {
            return number >> 1;
        }

        private bool IsPosition(int code, int mask)
        {
            return (code & mask) != 0;
        }

        private int AddOrRemovePosition(int code, int mask)
        {
            return code ^ mask;
        }

        private int GetMaskForPosition(int number)
        {
            return 1 << number;
        }

    }
}

