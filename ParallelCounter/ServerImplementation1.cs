using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClevTasks {
    // Uses volatile and Interlocked
    static class ServerImplementation1 {
        private static volatile int count;
        private static int GetCount() {
            // Because count is marked as volatile, it will always return the latest value
            return count;
        }

        private static void AddToCount(int value) {
            // Interlocked.Add ensures that the count will not change before its completion
            Interlocked.Add(ref count, value);
        }

        public static void Execute() {
            Task writer1 = Task.Run(() => {
                AddToCount(10);
            });

            Task writer2 = Task.Run(() => {
                AddToCount(5);
            });

            Task writer3 = Task.Run(() => {
                AddToCount(1);
            });

            Task.WhenAll(writer1, writer2, writer3).Wait();

            Console.WriteLine($"count: {GetCount()}");
        }
    }
}
