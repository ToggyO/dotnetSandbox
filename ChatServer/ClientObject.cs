using System;
using System.Net.Sockets;
using System.Text;

namespace ChatServer
{
    public class ClientObject
    {
        protected internal string Id { get; }
        protected internal NetworkStream Stream { get; private set; }

        private string _userName;
        private TcpClient _client;
        private ServerObject _server;

        public ClientObject(TcpClient tcpClient, ServerObject serverObject)
        {
            Id = Guid.NewGuid().ToString();
            _client = tcpClient;
            _server = serverObject;
            serverObject.AddConnection(this);
        }

        public void Process()
        {
            try
            {
                Stream = _client.GetStream();
                string message = GetMessage();
                _userName = message;
                message = _userName + " вошел в чат";
                
                _server.BroadcastMessage(message, Id);
                Console.WriteLine(message);

                while (true)
                {
                    try
                    {
                        message = GetMessage();
                        message = String.Format("{0}: {1}", _userName, message);
                        Console.WriteLine(message);
                        _server.BroadcastMessage(message, Id);
                    }
                    catch
                    {
                        message = String.Format("{0} покинул чат");
                        Console.WriteLine(message);
                        _server.BroadcastMessage(message, Id);
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                _server.RemoveConnection(Id);
                Close();
            }
        }

        private string GetMessage()
        {
            StringBuilder builder = new StringBuilder();
            byte[] data = new byte[64];
            int bytes = 0;
            
            do
            {
                bytes = Stream.Read(data, 0, data.Length);
                builder.Append(Encoding.UTF8.GetString(data, 0, bytes));
            } while (Stream.DataAvailable);

            return builder.ToString();
        }

        protected internal void Close()
        {
            if (_client != null)
                _client.Close();
            if (Stream != null)
                Stream.Close();
        }
    }
}