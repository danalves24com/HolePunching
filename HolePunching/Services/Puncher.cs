using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using HolePunching.Packets;

namespace HolePunching.Services
{
    class Puncher
    {

        public Puncher() {
           
        }

        public Puncher(string remoteIP, int remotePort) {
            this.remoteIp = remoteIP;
            this.remoreListeningPort = remotePort;
            this.localListeningPort = 42068;
        }

        public async void getLocalPublicIp() {
            string src = "http://ifconfig.me/ip";
            HttpClient client = new HttpClient();
            var ip = await client.GetStringAsync(src);
            Console.WriteLine("[local ip]\t{0}", ip);
            this.localIp = ip;
            
        }

        public string getLocalIp() {
            this.localIp = GetLocalIPAddress();
            return this.localIp;
        }

        private static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        public void generateLocations() {
            this.local = new Location(this.localIp, this.localListeningPort);
            this.remote = new Location(this.remoteIp, this.remoreListeningPort);
        }

        public int localListeningPort, remoreListeningPort;
        public string remoteIp, localIp;

        public Location remote, local;

        public void punch() {
            Location punchRemote = new Location(remoteIp, localListeningPort);
            Location punchLocal = new Location(localIp, remoreListeningPort);
            Packet packet = new Packet(punchRemote, "punch");
            packet.local = punchLocal;
            packet.send();
        
        }
        
    }
}
