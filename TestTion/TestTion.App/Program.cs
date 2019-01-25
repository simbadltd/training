using System;
using System.Net.Http;
using Microsoft.Owin.Hosting;

namespace TestTion.App
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string baseAddress = "http://localhost:9000/";

            // Start OWIN host
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                Console.WriteLine($"Server [{baseAddress}] is up and running...");
                Console.ReadLine();
            }
        }
    }
}