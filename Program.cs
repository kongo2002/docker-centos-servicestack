using System;
using System.Reflection;

using Mono.Unix;
using Mono.Unix.Native;

using Funq;

using ServiceStack;

namespace monotest
{
    public class AppHost : AppHostHttpListenerBase
    {
        public AppHost()
            : base("monotest", Assembly.GetExecutingAssembly())
        { }

        public override void Configure (Container container)
        { }
    }

    class MonoTest
    {
        public static void Main (string[] args)
        {
            Console.WriteLine ("Starting test deamon...");

            var exit = false;
            var signals = new[] {
                new UnixSignal(Signum.SIGINT),
                new UnixSignal(Signum.SIGTERM)
            };

            var host = new AppHost();

            host.Init();
            host.Start("http://+:8080/");

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
