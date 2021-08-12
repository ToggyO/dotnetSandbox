using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ConsoleServer
{
    class Program
    {
        private const int port = 8888;
        private const string host = "127.0.0.1";
        private static TcpListener server;
        
        static void Main(string[] args)
        {
            try
            {
                server = new TcpListener(IPAddress.Parse(host), port);
                server.Start();
                Console.WriteLine("Ожидание подключений...");

                while (true)
                {
                    TcpClient client = server.AcceptTcpClient();
                    ClientObject clientObject = new ClientObject(client);
                    
                    Thread thread = new Thread(clientObject.Process);
                    thread.Start();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                if (server != null)
                    server.Stop();
            }
        }
    }
}
