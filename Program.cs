using System;

using Mono.Unix;
using Mono.Unix.Native;

namespace monotest
{
    class MainClass
    {
        public static void Main (string[] args)
        {
            var exit = false;
            
            Console.WriteLine ("Starting test deamon...");
            
            var signals = new[] {
                new UnixSignal(Signum.SIGINT),
                new UnixSignal(Signum.SIGTERM)
            };
            
            
            // wait for termination
            while (!exit)
            {
                var id = UnixSignal.WaitAny(signals);
                
                if (id >= 0 && id < signals.Length)
                {
                    if (signals[id].IsSet)
                        exit = true;
                }
            }
        }
    }
}
