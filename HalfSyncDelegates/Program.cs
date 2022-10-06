namespace HalfSync {
    internal class Program {
        delegate int sumDelegate(int x, int y);
        static void Main(string[] args) {
            var g = new sumDelegate(sum);
            IAsyncResult res = g.BeginInvoke(1, 2, null, null);
            g.EndInvoke(res);
            Console.WriteLine(g);
        }

        private static int sum(int x, int y) {
            return x + y;
        }
    }    }