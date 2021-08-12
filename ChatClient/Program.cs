using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ChatClient
{
    class Program
    {
        private static string _userName;
        private static string _host = "127.0.0.1";
        private static int _port = 8888;
        private static TcpClient _client;
        private static NetworkStream _stream;
        
        static void Main(string[] args)
        {
            Console.Write("Введите свое имя: ");
            _userName = Console.ReadLine();
            _client = new TcpClient();

            try
            {
                _client.Connect(_host, _port);
                _stream = _client.GetStream();
                
                string message = _userName;
                byte[] data = Encoding.UTF8.GetBytes(message);
                _stream.Write(data, 0, data.Length);

                Thread thread = new Thread(ReceiveMessage);
                thread.Start();
                Console.WriteLine("Добро пожаловать, {0}", _userName);
                SendMessage();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Disconnect();
            }
        }

        private static void SendMessage()
        {
            Console.WriteLine("Введите сообщение: ");

            while (true)
            {
                string message = Console.ReadLine();
                byte[] data = Encoding.UTF8.GetBytes(message);
                _stream.Write(data, 0, data.Length);
            }
        }

        private static void ReceiveMessage()
        {
            while (true)
            {
                try
                {
                    StringBuilder builder = new StringBuilder();
                    byte[] data = new byte[64];
                    int bytes = 0;

                    do
                    {
                        bytes = _stream.Read(data, 0, data.Length);
                        builder.Append(Encoding.UTF8.GetString(data, 0, bytes));    
                    } while (_stream.DataAvailable);
                    
                    string message = builder.ToString();
                    Console.WriteLine(message);
                }
                catch
                {
                    Console.WriteLine("Подключение прервано!");
                    Console.ReadLine();
                    Disconnect();
                }
            }
        }

        private static void Disconnect()
        {
            if (_stream != null)
                _stream.Close();
            if (_client != null)
                _client.Close();
            Environment.Exit(0);
        }
    }
}
