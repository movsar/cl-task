using HalfSync;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ClevTasks {
   
    internal class Program {
        /* Requirements:
           Using delegates and "BeginInvoke", implement a way to call a method asynchronously,
           while having an opportunity to return its completion status based on a given timeout

           Solution:
           AsyncCaller - a class that runs a given method, checks how long does its execution take,
           and exits either when timeour runs out, or when the method completes successfully
         */
        static void Main(string[] args) {
            EventHandler h = new EventHandler(myEventHandler);
            var ac = new AsyncCaller(h);
            bool completedOK = ac.Invoke(5000, null, EventArgs.Empty);
            
            Console.WriteLine($"completedOK: {completedOK}");
            Console.Read();
        }

        private static void myEventHandler(object sender, EventArgs e) {
            var sw = Stopwatch.StartNew();
            
            // Task.Delay actually waits a bit longer than specified
            Task.Delay(4000).Wait();
            
            sw.Stop();
            Console.WriteLine($"The task took: {sw.ElapsedMilliseconds}");
        }
    }
}
