using ColorControl;
using System;

namespace SubscriberColorControl
{
    class Program
    {
        static void Main(string[] args)
        {
            string topic = "lamp123456789";
            MqttLib client = new MqttLib();
            client.StartConnection();
            Console.WriteLine("subscribing to: " + topic);
            client.Subscribe(topic);

            Console.ReadKey();

        }

    }
    
}
