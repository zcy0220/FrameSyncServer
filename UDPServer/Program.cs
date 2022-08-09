using System;

namespace UDPServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var socket = new UDPSocketServer(9000, 2);
            var a = 1;
        }
    }
}
