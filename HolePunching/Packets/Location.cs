using System;
using System.Collections.Generic;
using System.Text;

namespace HolePunching.Packets
{
    class Location
    {

        public Location(string ip, long port)
        {
            this.ip = ip;
            this.port = port;
        }
        public string ip { get; set; }
        public long port { get; set; }
    }
}
