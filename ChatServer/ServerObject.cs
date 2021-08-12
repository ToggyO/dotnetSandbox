using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ChatServer
{
    public class ServerObject
    {
        private string host = "127.0.0.1";
        private int port = 8888;
        private TcpListener _listener;
        private readonly IList<ClientObject> _clients = new List<ClientObject>();
        
        protected internal void AddConnection(ClientObject client)
        {
            _clients.Add(client);
        }

        protected internal void RemoveConnection(string id)
        {
            ClientObject client = _clients.FirstOrDefault(x => x.Id == id);
            if (client != null)
                _clients.Remove(client);
        }

        protected internal void BroadcastMessage(string message, string id)
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            foreach (var client in _clients)
            {
                if (client.Id != id)
                    client.Stream.Write(data, 0, data.Length);
            }
        }

        protected internal void Listen()
        {
            try
            {
                _listener = new TcpListener(IPAddress.Parse(host), port);
                _listener.Start();
                Console.WriteLine("Сервер запущен. Ожидание подключений...");

                while (true)
                {
                    TcpClient client = _listener.AcceptTcpClient();
                    ClientObject clientObject = new ClientObject(client, this);
                    Thread thread = new Thread(clientObject.Process);
                    thread.Start();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Disconnect();
            }
        }

        protected internal void Disconnect()
        {
            _listener.Stop();
            foreach (var client in _clients)
                client.Close();
            Environment.Exit(0);
        }
    }
}