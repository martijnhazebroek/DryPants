using System;
using System.Threading;

namespace DryPants.Test
{
    public static class TestExtensions
    {
        public static void OnMultipleThreads(this Action action, int numberOfThreads)
        {
            var threads = new Thread[numberOfThreads];
            for (int i = 0; i < numberOfThreads; i++)
            {
                threads[i] = new Thread(action.Invoke);
            }
            foreach (Thread thread in threads)
            {
                thread.Start();
            }
            foreach (Thread thread in threads)
            {
                thread.Join();
            }
        }
    }
}
