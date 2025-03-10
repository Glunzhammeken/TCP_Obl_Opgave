using System;
using System.IO;
using System.Net.Sockets;

namespace TCP_Obl_Opgave
{
    public class ClientHandler
    {
        public static void HandleClient(TcpClient tcpClient)
        {
            Console.WriteLine($"Client connected: {tcpClient.Client.RemoteEndPoint}");
            NetworkStream ns = tcpClient.GetStream();

            using (StreamReader reader = new StreamReader(ns))
            using (StreamWriter writer = new StreamWriter(ns) { AutoFlush = true })
            {
                bool isRunning = true;

                while (isRunning)
                {
                    string? msg = reader.ReadLine();
                    

                    if (msg == "Random")
                    {
                        writer.WriteLine("Input numbers");
                        string TwoNumbers = reader.ReadLine();
                        string[] parts = TwoNumbers.Split(' ');
                        int num1 = int.Parse(parts[0]);
                        int num2 = int.Parse(parts[1]);
                        Random rand = new Random();
                        writer.WriteLine($"{rand.Next(num1, num2)}");
                    }
                    else if (msg == "Add")
                    {
                        writer.WriteLine("Input numbers");
                        string TwoNumbers = reader.ReadLine();
                        string[] parts = TwoNumbers.Split(' ');
                        int num1 = int.Parse(parts[0]);
                        int num2 = int.Parse(parts[1]);
                        writer.WriteLine($"{num1 + num2}");
                    }
                    else if (msg == "Subtract")
                    {
                        writer.WriteLine("Input numbers");
                        string TwoNumbers = reader.ReadLine();
                        string[] parts = TwoNumbers.Split(' ');
                        int num1 = int.Parse(parts[0]);
                        int num2 = int.Parse(parts[1]);
                        writer.WriteLine($"{num1 - num2}");
                    }
                    else if (msg == "close")
                    {
                        isRunning = false;
                        writer.WriteLine("Connection closed.");
                        Console.WriteLine($"Client disconnected: {tcpClient.Client.RemoteEndPoint}");
                    }
                    else
                    {
                        writer.WriteLine("Unknown command.");
                    }
                }
            }
            tcpClient.Close();
        }
    }
}
