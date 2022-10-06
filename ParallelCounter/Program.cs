namespace ClevTasks {
    internal class Program {
        /*
         Requirements:
         A static "Server" class, should implement AddToCount and GetCount
         methods, that will work with concurrently happening requests to change
         and read a single "count" variable.

         Value change must be happen in the same order as they were requested

         Value retrievals must be allowed in parallel without ordering

         Solution:
         ServerImplementation1 - using "volatile" keyword and "Interlocked" class
         ServerImplementation2 - using "volatile" and "lock" keywords
         */
        static void Main(string[] args) {
            // There are two implementations of this task
            ServerImplementation1.Execute();
            ServerImplementation2.Execute();
        }
    }
}
