using System;
using System.IO;
using System.Net.Sockets;

namespace TCP_Obl_Opgave
{
    public class ClientTcp
    {
        public static void StartClient()
        {
            string serverIp = "127.0.0.1"; 
            int port = 5000; 

            try
            {
                using (TcpClient client = new TcpClient(serverIp, port))
                using (NetworkStream stream = client.GetStream())
                using (StreamReader reader = new StreamReader(stream))
                using (StreamWriter writer = new StreamWriter(stream) { AutoFlush = true })
                {
                    Console.WriteLine("Connected to server!");

                    bool isRunning = true;

                    while (isRunning)
                    {
                        Console.Write("Enter command (Random, Add, Subtract, close): ");
                        string command = Console.ReadLine();
                        writer.WriteLine(command);

                        if (command == "close")
                        {
                            isRunning = false;
                        }
                        else if (command == "Random" || command == "Add" || command == "Subtract")
                        {
                            Console.WriteLine(reader.ReadLine()); 
                           
                            string numbers = Console.ReadLine();
                            writer.WriteLine(numbers);
                            Console.WriteLine("Server response: " + reader.ReadLine());
                        }
                        else
                        {
                            Console.WriteLine("Unknown command.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.WriteLine("Client closed.");
        }
    }
}
