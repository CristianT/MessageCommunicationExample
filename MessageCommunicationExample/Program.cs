using EasyNetQ;
using MessageContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MessageCommunicationExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // open bus
            var bus = RabbitHutch.CreateBus("host=127.0.0.1;timeout=0");

            var i = 0;
            while(true)
            {
                var s = i.ToString();
                i++;

                // publish message
                Log("Publishing " + s);
                bus.Publish(new ExampleMessage() { Test = s });

                Thread.Sleep(500);
            }
        }

        private static void Log(string s)
        {
            Console.WriteLine(s);
        }
    }
}
