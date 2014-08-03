using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CA.Algorithms.Data.Knapsack
{
    public class KnapsackDataManager : IKnapsackDataManager
    {
        public KnapsackData GetData()
        {
            const string dataPath = 
            //    @"..\..\..\CA.Algorithms\Data\Knapsack\knapsack1.txt";
                @"..\..\..\CA.Algorithms\Data\Knapsack\knapsack_big.txt";
            //    @"..\..\..\CA.Algorithms\Data\Knapsack\knapsackTestData.txt";
            using (TextReader reader = File.OpenText(dataPath))
            {
                var data = new KnapsackData();

                var text = reader.ReadLine();

                var knapsackParams = text.Split(' ');

                data.KnapsackSize = int.Parse(knapsackParams[0]);
                var itemsCount = int.Parse(knapsackParams[1]);
                data.Items = new KnapsackItem[itemsCount];

                text = reader.ReadLine();

                int counter = 0;
                while (text != null)
                {
                    var knapsackItem = text.Split(' ');

                    data.Items[counter] = new KnapsackItem(int.Parse(knapsackItem[1]), int.Parse(knapsackItem[0]));

                    counter++;
                    text = reader.ReadLine();
                }

                data.Items = data.Items.OrderByDescending(i => i.Weight).ToArray();

                return data;
            }
        }
    }
}
