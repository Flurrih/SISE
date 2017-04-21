using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISE_ONE
{
    public static class Time
    {
        static Stopwatch watch = new Stopwatch();

        public static void StartTimer()
        {
            watch.Reset();
            watch.Start();
        }

        public static double StopTimer()
        {
            watch.Stop();
            return watch.Elapsed.TotalSeconds;
        }
    }
}
