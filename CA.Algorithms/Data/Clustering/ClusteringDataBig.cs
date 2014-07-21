using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CA.Algorithms.Data.Clustering
{
    public class ClusteringDataBig : IClusteringBigData
    {
        public ClusteringItem[] GetData()
        {
            using (TextReader reader = File.OpenText(@"..\..\..\CA.Algorithms\Data\Clustering\clustering_big.txt"))//clusteringbigtest.txt clustering_big.txt
            {
                var text = reader.ReadLine();

                // initialize cluster size
                var sizes = text.Split(' ');
                var itemSize = int.Parse(sizes[0]);
                var bitSize = int.Parse(sizes[1]);


                var cluster = new ClusteringItem[itemSize];

                for (var i = 0; i < cluster.Length; i++)
                {
                    cluster[i]= new ClusteringItem(i, bitSize);
                }

                text = reader.ReadLine();
                var itemNumber = 0;
                while (text != null)
                {
                    var textSplited = text.Split(' ');

                    for (int i = 0; i < bitSize; i++)
                    {
                        var bit = int.Parse(textSplited[i]);

                        cluster[itemNumber].IntData += bit * (int)Math.Pow(2, i);

                        cluster[itemNumber].ItemData[i] = bit == 1;
                    }

                    itemNumber++;
                    text = reader.ReadLine();
                }

                return cluster;
            }
        }
    }
}
