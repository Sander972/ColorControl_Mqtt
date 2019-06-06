using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace ColorControl
{
    public class MqttLib
    {
        public MqttClient Client { get; set; }
        public string ClientId { get; set; }

        public MqttLib() { }

        public void StartConnection()
        {
            //string BrokerAddress = "test.mosquitto.org";
            string BrokerAddress = "broker.hivemq.com";
            Client = new MqttClient(BrokerAddress);
            Client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
            ClientId = Guid.NewGuid().ToString();

            Client.Connect(ClientId);
        }

        public void CloseConnection()
        {
            Client.Disconnect();
        }

        public void Subscribe(string topic)
        {
            Client.Subscribe(new string[] { topic }, new byte[] { 2 });
        }

        public void Publish(string topic, string value, byte qos, bool retainFlag)
        {
            Client.Publish(topic, Encoding.UTF8.GetBytes(value), qos, retainFlag);
        }

        void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            string ReceivedMessage = Encoding.UTF8.GetString(e.Message);

            ConsoleColor consoleColor = ConsoleColor.White;
            try
            {
                consoleColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), ReceivedMessage, true);
            }
            catch (Exception)
            {
                //Invalid color
            }

            Console.BackgroundColor = consoleColor;
            Console.WriteLine($"\n Message: {ReceivedMessage}");
        }
    }
}


