using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace SpeedMeasure
{
    public class Measure
    {
        public Measure(string name)
        {
            _name = name;
        }

        private readonly string _name;
        private TimeSpan _start;
        private  TimeSpan _end;

        public void StartMeasure()
        {
            _start = Process.GetCurrentProcess().TotalProcessorTime;
        }

        public void StopMeasureDisplay()
        {
            _end = Process.GetCurrentProcess().TotalProcessorTime;
            Console.WriteLine("Measured time {0}: {1} ms.", _name, (_end - _start).TotalMilliseconds);
        }

    }
}
