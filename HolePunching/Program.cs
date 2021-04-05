using System;
using System.Threading;
using System.Xml;
using HolePunching.Packets;
using HolePunching.Services;


namespace HolePunching
{


    class Program
    {

        private static void punch()
        {

        }

        static void Main(string[] args)
        {


            XmlDocument doc = new XmlDocument();
            doc.Load(args.Length == 0 ? "../../../conf.xml" : args[0]);



            // ADD XML
            string targetIP = doc.SelectNodes("//remote//IP")[0].InnerText;
            string localIP = doc.SelectNodes("/config/local/IP")[0].InnerText;
            int targetPort = int.Parse(doc.SelectNodes("/config/remote/PORT")[0].InnerText);
            int localPort = int.Parse(doc.SelectNodes("/config/local/PORT")[0].InnerText);


            Menu menu = new Menu();
            menu.show();
            String choice = menu.choice;            
            switch (choice)
            {
                case "0":


                    Puncher puncher = new Puncher(targetIP, targetPort);
                    Console.WriteLine("[status]\tpreparing punch packet for {0}:{1}", targetIP, targetPort);
                    puncher.getLocalIp();
                    Thread.Sleep(1000);
                    puncher.generateLocations();
                    Console.WriteLine("[status]\tsending packet");
                    puncher.punch();
                    Console.WriteLine("[status]\tpacket sent");
                    break;
                case "1":
                    Console.WriteLine("[status]\tpreparing packet for {0}:{1}", targetIP, targetPort);
                    PacketBuilder builder = new PacketBuilder();
                    Location location = new Location(ip: targetIP, port: targetPort);                    
                    Location local = new Location(localIP, localPort); 

                    Console.WriteLine("[status]\tsending from {0}:{1}", localIP, localPort);
                    builder.destination = location;
                    builder.body = "helo";
                    
                    Packet packet = builder.build();
                    packet.local = local;
                    packet.send();
                    break;

                case "3":
                    Listener listener = new Listener();
                    listener.ReceiveMessages(localPort);
                    break;
                default:
                    Console.WriteLine("not found");
                    break;
            }

            /*
             *             // sender
                        PacketBuilder builder = new PacketBuilder();
                        Location location = new Location(ip: "10.10.10.1", port: 42069);

                        builder.destination = location;
                        builder.body = "helo";
                        builder.build().send();

             */



        }
    }
}

