using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CA.Algorithms.Data._2Sum
{
    public class Get2SumDataFs : IGet2SumData
    {
        public int[] GetData()
        {
            using (TextReader reader = File.OpenText(@"..\..\..\CA.Algorithms\Data\2Sum\HashInt.txt"))
            {
                var array = new List<int>();
                string text = reader.ReadLine();
                while (text != null)
                {
                    int i;
                    if (int.TryParse(text, out i))
                    {
                        array.Add(i);
                    }

                    text = reader.ReadLine();
                }

                return array.ToArray();
            }
        }
    }
}
