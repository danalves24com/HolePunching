using System;
using System.Collections.Generic;
using System.Text;

namespace HolePunching.Packets
{
    class PacketBuilder
    {

        public Location destination { get; set; }
        public string body { get; set; }
        public Packet build() {
            Packet packet = new Packet(destination, body);
            return packet;
        }


    }
}
