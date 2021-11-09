using System;
using System.Threading;

namespace ShipPort
{
    public class StagingArea
    {
        public static readonly SemaphoreSlim freeinport = new SemaphoreSlim(5);
        public static readonly SemaphoreSlim freedocks = new SemaphoreSlim(3);
        
        public static readonly SemaphoreSlim ssa = new SemaphoreSlim(0);

        public static void Run()
        {
            while (true)
            {
                ssa.Wait();
                
                freeinport.Wait();
                Ship.ss.Release();
                
                freedocks.Wait();
                Signal();
                Ship.ss.Release();
            }
        }

        public static void Signal()
        {
            Thread.Sleep(200);
            Console.WriteLine("Stagingare: signaling ship");
        }
    }
}