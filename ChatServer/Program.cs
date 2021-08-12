using System;
using System.Threading;

namespace ChatServer
{
    class Program
    {
        private static ServerObject _server;
        private static Thread _mainThread;
        
        static void Main(string[] args)
        {
            try
            {
                _server = new ServerObject();
                _mainThread = new Thread(_server.Listen);
                _mainThread.Start();

            }
            catch (Exception e)
            {
                _server.Disconnect();
                Console.WriteLine(e.Message);
            }
        }
    }
}
