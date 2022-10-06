using System;
using System.Diagnostics;

namespace HalfSync {
    class AsyncCaller {
        EventHandler _eventHandler;
        public AsyncCaller(EventHandler eventHandler) {
            _eventHandler = new EventHandler(eventHandler);
        }

        public bool Invoke(int timeout, object sender, EventArgs args) {
            IAsyncResult asyncResult = _eventHandler.BeginInvoke(sender, args, null, null);

            var sw = Stopwatch.StartNew();

            // Waits until the task completes or timeout runs out
            while (!asyncResult.IsCompleted) {
                if (sw.ElapsedMilliseconds > timeout) {
                    sw.Stop();
                    return false;
                }
            }

            sw.Stop();

            _eventHandler.EndInvoke(asyncResult);

            return true;
        }

    }
}
