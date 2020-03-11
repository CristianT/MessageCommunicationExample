using EasyNetQ;
using MessageContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MessageCommunicationExampleReceiver
{
    class Program
    {
        static void Main(string[] args)
        {
            // open bus
            var bus = RabbitHutch.CreateBus("host=127.0.0.1;timeout=0");

            bus.Subscribe<ExampleMessage>("ExampleMessageSubscription", HandleReceiveMessage);

            Log("Press enter to exit...");
            Console.ReadLine();
        }

        private static void HandleReceiveMessage(ExampleMessage msg)
        {
            Log("Received: " + msg.Test);
        }

        private static void Log(string s)
        {
            Console.WriteLine(s);
        }
    }
}
