using System;
using System.Net.Sockets;
using System.Text;

namespace ConsoleClient
{
    class Program
    {
        private const string address = "127.0.0.1";
        private const int port = 8888;
        
        static void Main(string[] args)
        {
            Console.WriteLine("Введите имя: ");
            string userName = Console.ReadLine();
            TcpClient client = null;

            try
            {
                client = new TcpClient(address, port);
                NetworkStream stream = client.GetStream();

                while (true)
                {
                    Console.Write(userName + ": ");
                    string message = Console.ReadLine();
                    message = String.Format("{0}: {1}", userName, message);

                    byte[] data = Encoding.UTF8.GetBytes(message);
                    stream.Write(data, 0, data.Length);

                    data = new byte[64];
                    StringBuilder response = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = stream.Read(data, 0, data.Length);
                        response.Append(Encoding.UTF8.GetString(data, 0, bytes));
                    } while (stream.DataAvailable);

                    message = response.ToString();
                    Console.WriteLine("Сервер: {0}", message);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                client.Close();
            }
        }
    }
}
