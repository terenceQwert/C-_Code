using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;
namespace ConsoleApp1
{
    public class Fan
    {
        public string Name { get; set; }
        public DateTime Admittted { get; set; }
        public int AdmittranceGateNumber { get; set; }
    }
    static class MultipleTask {
        private static ConcurrentDictionary<int, Fan> stadiumGates = new ConcurrentDictionary<int, Fan>();
        private static bool monitorGates = true;
        public static void TestMultipleGate()
        {
            List<Fan> fansAttending = new List<Fan>();
            for( int i =0;i<100;i++)
            {
                fansAttending.Add(new Fan() { Name = "Fan" +i});
            }
            Fan[] fans = fansAttending.ToArray();
            int gateCount = 10;
            Task[] entryGates = new Task[gateCount];
            Task[] securityMonitors = new Task[gateCount];

            for( int gateNumber = 0; gateNumber < gateCount;gateNumber ++)
            {
                int GateNum = gateNumber;
                Action action = delegate () { AdmitFans(fans, GateNum, gateCount); };
                entryGates[GateNum] = Task.Run(action);
            }
            Task.WhenAll(entryGates).Wait();
            for( int gateNumber = 0;gateNumber < gateCount;gateNumber ++)
            {
                int GateNum = gateNumber;
                Action action = delegate () { MonitorGate(GateNum); };
                securityMonitors[gateNumber] = Task.Run(action);
            }
            Task.WhenAll(securityMonitors).Wait();

            // turn off monitors
            monitorGates = false;
        }
        private static void AdmitFans( Fan[] fans, int gateNumber, int gateCount)
        {
            Random rnd = new Random();
            int fansPerGate = fans.Length / gateCount;
            int start = gateNumber * fansPerGate;
            int end = start + fansPerGate - 1;
            for( int f= start;f<=end;f++)
            {
                Console.WriteLine($"Admitting {fans[f].Name} through gate {gateNumber}");
                var fanAtGate = stadiumGates.AddOrUpdate(gateNumber, fans[f], (key, fanInGate) =>
                {
                    Console.WriteLine($"{fanInGate.Name} was replaced by " + $"{fans[f].Name} in gate {gateNumber}");
                    return fans[f];
                });
                Thread.Sleep(rnd.Next(500, 2000));
                fans[f].Admittted = DateTime.Now;
                fans[f].AdmittranceGateNumber = gateNumber;
                Fan fanAdmited;
                if( stadiumGates.TryRemove(gateNumber, out fanAdmited))
                {
                    Console.WriteLine($"{fanAdmited.Name} entering event from gate " +
                        $"{fanAdmited.AdmittranceGateNumber} on " +
                        $"{fanAdmited.Admittted.ToShortTimeString()}");
                }
                else
                {
                    Console.WriteLine($"{fanAdmited.Name} held by security " +
                        $"at gate {fanAdmited.AdmittranceGateNumber}");
                }
            }

        }
        private static void MonitorGate( int gateNumber)
        {
            Random rnd = new Random();
            while( monitorGates)
            {
                Fan currntFanInGate;
                if (stadiumGates.TryGetValue(gateNumber, out currntFanInGate))
                    Console.WriteLine($"Monitor: {currntFanInGate.Name} is in Gate " +
                        $"{gateNumber}");
                else
                    Console.WriteLine($"Monitor: NO fan is in Gate {gateNumber}");

                Thread.Sleep(rnd.Next( 500, 5000));
            }
        }
        public static int Count<TSource>( this IEnumerable<TSource> source)
        {
            if( source == null)
            {
                throw new ArgumentNullException("source");
            }
            ICollection<TSource> tSources = source as ICollection<TSource>;
            if(tSources != null)
            {
                return tSources.Count;
            }
            ICollection collections = source as ICollection;
            if (collections != null)
                return collections.Count;
            int num = 0;
            using (IEnumerator<TSource> enumator = source.GetEnumerator())
            {
                while (enumator.MoveNext())
                    num++;

            }
            return num;
        }
    }
}
