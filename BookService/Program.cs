using System;
using System.Net.Http;
using Microsoft.Owin.Hosting;


namespace BookService
{
    class Program
    {
        static readonly Uri _baseAddress = new Uri("http://localhost:9898/");

        static void Main(string[] args)
        {
            try
            {
                using (WebApp.Start<Startup>(url: _baseAddress.OriginalString))
                {
                    Console.WriteLine("Listening on " + _baseAddress);
                    Console.WriteLine("Hit ENTER to exit...");
                    Console.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not start server: {0}", e.GetBaseException().Message);
            }
            finally
            {
                Console.WriteLine("Hit ENTER to exit...");
                Console.ReadLine();
            }
        }
    }
}
