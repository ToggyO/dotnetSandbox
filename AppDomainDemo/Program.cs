using System;
using System.Collections.Generic;

namespace AppDomainDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (new AppDomainMonitorDelta(null))
            {
                var list = new List<object>();
                for (int x = 0; x < 1000; x++)
                    list.Add(new byte[10000]);

                for (int x = 0; x < 2000; x++)
                    new byte[10000].GetType();

                int stop = Environment.TickCount + 5000;
                while (Environment.TickCount < stop) ;
            }
        }
    }
}
