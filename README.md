# ClevTasks

## Task 1:

### Requirements:
>Using delegates and "BeginInvoke", implement a way to call a method asynchronously, while returning its completion status based on a given timeout

### Solution:
>AsyncCaller - a class that runs a given method, checks how long does its execution take, and exits either when timeour runs out, or when the method completes successfully

## Task 2:
### Requirements:
>1. A static "Server" class, should implement AddToCount and GetCount methods, that will work with concurrently happening requests to change and read a single "count" variable.
>2. Value changes must happen in the same order as they were requested
>3. Value retrievals must be allowed in parallel without ordering

### Solution 1:
ServerImplementation1 - using "volatile" keyword and "Interlocked" class
### Solution 2:
ServerImplementation2 - using "volatile" and "lock" keywords
