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
            Log("Usage: MessageCommunicationExampleReceiver.exe <queue to listen to> [queue to fordward to]");
            try
            {
                if (args.Length < 1)
                {
                    throw new Exception("Error in parameters.");
                }

                var queueName = args[0];
                Log("Listening on queue: " + queueName);

                if (args.Length == 2)
                {
                    FordwardingQueue = args[1];
                }

                // open bus
                bus = RabbitHutch.CreateBus("host=127.0.0.1;timeout=0");

                bus.Subscribe<ExampleMessage>("ExampleMessageSubscription", HandleReceiveMessage);

                bus.Receive<ExampleMessage>(queueName, HandleReceiveMessage);
            }
            catch(Exception ex)
            {
                Log($"Error: {ex.Message}");
            }

            Log("Press enter to exit...");
            Console.ReadLine();

            bus.Dispose();
        }

        static IBus bus;
        static string FordwardingQueue = null;

        private static void HandleReceiveMessage(ExampleMessage msg)
        {
            Log("Received: " + msg.Test);

            if(FordwardingQueue != null)
            {
                Log("Forwarding to " + FordwardingQueue);
                bus.Send(FordwardingQueue, msg);
            }
        }

        private static void Log(string s)
        {
            Console.WriteLine(s);
        }
    }
}
