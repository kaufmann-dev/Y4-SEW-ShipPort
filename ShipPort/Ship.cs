using System;
using System.Threading;

namespace ShipPort
{
    public class Ship
    {
        public static readonly SemaphoreSlim ss = new SemaphoreSlim(0);
        
        public string Id { get; set; }

        public Ship(string id)
        {
            Id = id;
        }

        public void Run()
        {
            StagingArea.ssa.Release();
            
            ss.Wait();
            MoveIntoPort();
            
            ss.Wait();
            
            Unload();
            StagingArea.freedocks.Release();
            StagingArea.freeinport.Release();
        }

        public void Unload()
        {
            Thread.Sleep(500);
            Console.WriteLine($"Unloading ship: {Id}");
        }

        public void MoveIntoPort()
        {
            Thread.Sleep(200);
            Console.WriteLine($"Ship {Id} moved into port");
        }
    }
}