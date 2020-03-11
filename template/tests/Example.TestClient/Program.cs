﻿using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Example.Client;
using Example.Protos;

namespace Example.TestClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Press enter to start");
            Console.ReadLine();
            var client = new ExampleClient("http://localhost:5001");

            while (true)
            {
                try
                {
                    var sw = new Stopwatch();
                    sw.Start();
                    var result = await client.Monitoring.IsAliveAsync(new IsAliveRequest());
                    sw.Stop();
                    Console.WriteLine($"{result.Name}  {sw.ElapsedMilliseconds} ms");
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Thread.Sleep(1000);
            }
        }
    }
}
