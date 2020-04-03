using Nancy.Hosting.Self;
using System;

namespace C3Server
{
    class Program
    {
        static void Main(string[] args)
        {
            SetTest.CreateSet();

            HostConfiguration hostConfiguration = new HostConfiguration()
            {
                UrlReservations = new UrlReservations() { CreateAutomatically = true },
            };

            using (var host = new NancyHost(hostConfiguration, new Uri("http://localhost:1234")))
            {
                host.Start();
                Console.WriteLine("Running on http://localhost:1234");
                Console.ReadLine();
                host.Stop();
            }


        }

    }
}
