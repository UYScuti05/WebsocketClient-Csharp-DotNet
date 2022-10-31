using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using Newtonsoft.Json;

namespace csharp_client
{

    public class Message1 {
        public string action;
        public string senderEmail;
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string websocketURL = "";
            using (WebSocket ws = new WebSocket(websocketURL))
            {
                Message1 firstMessage = new Message1();
                firstMessage.action = "setEmail";
                firstMessage.senderEmail = "hello@gmail.com";
                string jsonResult = JsonConvert.SerializeObject(firstMessage);
                Console.WriteLine("Server own message is...");
                Console.WriteLine(jsonResult);
                ws.Connect();
                ws.Send(jsonResult);
                ws.OnMessage += Ws_OnMessage;

                Console.ReadKey();
            };
        }

        private static void Ws_OnMessage(object sender, MessageEventArgs e)
        {
            Console.WriteLine("Received from server: " + e.Data);
        }
    }
}
