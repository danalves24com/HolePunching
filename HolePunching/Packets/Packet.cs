﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace HolePunching.Packets
{
    class Packet
    {
        public Packet() { 
        }
        private Location target;
        public Location local;
        private String body;
        public Packet(Location target, String body) {
            this.target = target;
            this.body = body;
        }
        public void send() {
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram,ProtocolType.Udp);
            

            IPEndPoint localEP = new IPEndPoint(IPAddress.Parse(this.local.ip), (int)this.local.port);

            IPAddress serverAddr = IPAddress.Parse(this.target.ip);
            IPEndPoint endPoint = new IPEndPoint(serverAddr, (int)this.target.port);

            Console.WriteLine("sending to " + endPoint + " from " + local);

            sock.Bind(localEP);

            

            byte[] send_buffer = Encoding.ASCII.GetBytes(this.body);

            
            sock.SendTo(send_buffer, endPoint);
        }
    }
}
