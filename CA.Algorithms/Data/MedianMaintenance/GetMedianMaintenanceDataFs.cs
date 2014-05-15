using System.Collections.Generic;
using System.IO;

namespace CA.Algorithms.Data.MedianMaintenance
{
    public class GetMedianMaintenanceDataFs : IGetMedianMaintenanceData
    {
        public IEnumerable<int> GetData()
        {
            using (TextReader reader = File.OpenText(@"..\..\..\CA.Algorithms\Data\MedianMaintenance\Median.txt"))
            {
                string text = reader.ReadLine();
                while (text != null)
                {
                    yield return int.Parse(text);

                    text = reader.ReadLine();
                }
            }
        }
    }
}
