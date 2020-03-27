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
            Console.WriteLine("Press enter to start...");
            Console.ReadLine();

            // open bus
            var bus = RabbitHutch.CreateBus("host=127.0.0.1;timeout=0");
            int i = 0;

            // Publish example
            for(;i<10;i++)
            {
                var s = $"Publish{i}";

                // publish message
                Log("Publishing " + s);
                bus.Publish(new ExampleMessage() { Test = s });

                Thread.Sleep(100);
            }

            // Send queue 1 example
            for (; i < 20; i++)
            {
                var s = $"Send{i}";

                // send message
                Log("Sending to  Queue1: " + s);
                bus.Send("Queue1", new ExampleMessage() { Test = s });

                Thread.Sleep(100);
            }

            // Send queue 2 example
            for (; i < 30; i++)
            {
                var s = $"Send{i}";

                // send message
                Log("Sending to  Queue2: " + s);
                bus.Send("Queue2", new ExampleMessage() { Test = s });

                Thread.Sleep(100);
            }

            bus.Dispose();
        }

        private static void Log(string s)
        {
            Console.WriteLine(s);
        }
    }
}
